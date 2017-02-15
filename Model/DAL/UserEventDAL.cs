using Model.EF;
using Model.Helper;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Model.DAL
{
    public class UserEventDAL
    {
        SgmSystemDbContext db = null;
        public UserEventDAL()
        {
            db = new SgmSystemDbContext();
        }

        public IEnumerable<UserEventListViewModel> UeListAll(int type)
        {
            var model = db.tbl_UserEvent.Where(m => m.UeCount == type).Select(m => new UserEventListViewModel
            {
                UeID = m.UeID,
                UserID = m.UserID,
                UeCreateDate = m.UeCreateDate,
                UeDateExpires = m.UeDateExpires,
                UeWillExpires = m.UeWillExpires,
                UeNote = m.UeNote,
                UeOk = m.UeOk == true ? "Đã Duyệt" : "Chờ Duyệt",
                Color = m.UeOk == true ? "success" : "default"
            }).OrderByDescending(m => m.UeCreateDate);
            return model;
        }

        public IEnumerable<UserEventAdminListViewModel> UeListAllForAdmin()
        {
            UsersDAL userModel = new UsersDAL();
            var model = db.tbl_UserEvent.ToList();
            List<UserEventAdminListViewModel> liHomeView = new List<UserEventAdminListViewModel>();

            foreach (var item in model)
            {
                UserEventAdminListViewModel ueModel = new UserEventAdminListViewModel();
                ueModel.UserID = item.UserID;
                ueModel.UserFullName = userModel.GetUser(item.UserID).UserFullName;
                ueModel.UserPhone = userModel.GetUser(item.UserID).UserPhone;
                ueModel.UeDateExpires = item.UeDateExpires;
                ueModel.UeWillExpires = item.UeWillExpires;
                ueModel.UeNote = item.UeNote;
                ueModel.Loai = item.UeCount == (int)Enums.EventType.CongTac ? "Công Tác" : "Nghỉ Phép";
                ueModel.Color = item.UeCount == 1 ? item.UeOk == true? "success": "default" : item.UeOk == true ? "success" : "danger";
                ueModel.UeOk = item.UeOk;
                ueModel.UeID = item.UeID;
                ueModel.UeCount = item.UeCount;
                liHomeView.Add(ueModel);
            }


            return liHomeView;
        }

        public long AcceptEvent(UserEventAdminListViewModel userEventModel)
        {
            var result = db.Database.ExecuteSqlCommand("exec proc_as_AcceptUpdateAttanceDanceForUser @UserID, @UeType, @UeID", 
                new SqlParameter("@UserID",userEventModel.UserID),
                new SqlParameter("@UeType",userEventModel.UeCount),
                new SqlParameter("@UeID",userEventModel.UeID));

            return result;
        }

        public IEnumerable<UserEventListHomeViewModel> UeListAllHome()
        {
            UsersDAL userModel = new UsersDAL();
            //var model = db.tbl_UserEvent.Select(m => new UserEventListHomeViewModel
            //{
            //    UserID = m.UserID,
            //    UserFullName = userModel.GetUser(m.UserID).UserFullName,
            //    UserPhone = userModel.GetUser(m.UserID).UserPhone,
            //    UeDateExpires = m.UeDateExpires,
            //    UeWillExpires = m.UeWillExpires,
            //    UeNote = m.UeNote,
            //    Loai = m.UeCount == (int)Enums.EventType.CongTac ? "Công Tác" : "Nghỉ Phép",
            //    Color = m.UeCount == 1 ? "success" : "default"
            //}).OrderByDescending(m=>m.UeDateExpires);


            var model = db.tbl_UserEvent.ToList();
            List<UserEventListHomeViewModel> liHomeView = new List<UserEventListHomeViewModel>();

            foreach (var item in model)
            {
                UserEventListHomeViewModel ueModel = new UserEventListHomeViewModel();
                ueModel.UserID = item.UserID;
                ueModel.UserFullName = userModel.GetUser(item.UserID).UserFullName;
                ueModel.UserPhone = userModel.GetUser(item.UserID).UserPhone;
                ueModel.UeDateExpires = item.UeDateExpires;
                ueModel.UeWillExpires = item.UeWillExpires;
                ueModel.UeNote = item.UeNote;
                ueModel.Loai = item.UeCount == (int)Enums.EventType.CongTac ? "Công Tác" : "Nghỉ Phép";
                ueModel.Color = item.UeCount == 1 ? "success" : "default";
                liHomeView.Add(ueModel);
            }


            return liHomeView;
        }

        public IEnumerable<UserEventListViewModel> UeListAllByUser(int type, int userID)
        {
            var model = db.tbl_UserEvent.Where(m => m.UeCount == type && m.UserID == userID).Select(m => new UserEventListViewModel
            {
                UeID = m.UeID,
                UserID = m.UserID,
                UeCreateDate = m.UeCreateDate,
                UeDateExpires = m.UeDateExpires,
                UeWillExpires = m.UeWillExpires,
                UeNote = m.UeNote,
                UeOk = m.UeOk == true ? "Đã Duyệt" : "Chờ Duyệt",
                Color = m.UeOk == true ? "success" : "default"
            });

            return model;
        }

        public long CreateUserEvent(UserEventCreateViewModel createModel)
        {
            var result = CheckFromDateToDate(createModel.UeDateExpires.Value, createModel.UeWillExpires.Value, createModel.UserID.Value);
            if (result == 1)
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    var model = new tbl_UserEvent();
                    model.EventID = createModel.EventID;
                    model.UserID = createModel.UserID;
                    model.UeCount = createModel.UeType; //Phep hay Cong tac
                    model.UeOk = false;
                    model.UeCreateDate = DateTime.Now;
                    model.UeDateExpires = createModel.UeDateExpires;
                    model.UeNote = createModel.UeNote;
                    model.UeWillExpires = createModel.UeWillExpires;
                    model.UeCount = createModel.UeType;

                    db.tbl_UserEvent.Add(model);
                    db.SaveChanges();

                    int UeId = model.UeID;

                    AttandanceDAL modelAtt = new AttandanceDAL();
                    createModel.UeID = model.UeID;
                    var kq = modelAtt.CheckCongThem(createModel);

                    scope.Complete();
                    return result;
                }
            }
            return result;
        }

        public long CheckFromDateToDate(DateTime fromDate, DateTime toDate, int userID)
        {

            if (toDate.Date < fromDate.Date)
            {
                //message = "Ngày bắt đầu không được lớn hơn ngày kết thúc!";
                return -1;
            }

            var resultUnique = db.tbl_UserEvent.Where(m => m.UserID == userID && m.UeWillExpires >= fromDate.Date).Count();

            if (resultUnique > 0)
            {
                //message = "Bạn đã đăng ký nghỉ thời gian này!";
                return -2;
            }

            //message = "yes";
            return 1;
        }

        public int DeleteUserEventAndAttandanceById(int UserEventID)
        {
            tbl_UserEvent tbl_UserEvent = db.tbl_UserEvent.Find(UserEventID);

            var result = db.Database.ExecuteSqlCommand("exec proc_as_DeleteAttandanceAndUserEvent @UeID,@UserID", 
                new SqlParameter("@UeID", UserEventID), 
                new SqlParameter("@UserID",tbl_UserEvent.UserID));

            return result;
        }
    }
}
