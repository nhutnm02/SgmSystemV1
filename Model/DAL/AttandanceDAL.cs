using Model.EF;
using Model.ViewModel;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace Model.DAL
{
    public class AttandanceDAL
    {
        SgmSystemDbContext db = null;
        public AttandanceDAL()
        {
            db = new SgmSystemDbContext();
        }

        public AttandanceViewModel ListAllOfUser(int userID)
        {
            UsersDAL uDao = new UsersDAL();
            var user = uDao.GetUser(userID);
            var currentMonth = DateTime.Now.Month;

            AttandanceViewModel model = new AttandanceViewModel();
            model.UserID = userID;
            model.ClientName = user.UserFullName;
            model.CongDung = TinhCong(currentMonth,userID, Enums.LoaiCong.CongDung);
            model.CongThem = TinhCong(currentMonth,userID, Enums.LoaiCong.CongThem);
            model.CongTre = TinhCong(currentMonth,userID, Enums.LoaiCong.CongTre);
            model.CongPhep = TinhCong(currentMonth,userID, Enums.LoaiCong.CongPhep);
            model.CurrentMonth = "Tháng " + currentMonth.ToString();
            model.ListAttan = listAtOfUser(userID);
            model.DdlMonth = DdlMonth(DateTime.Now.Month);
            //var model = db.tbl_Attandance.Select(m => new AttandanceViewModel
            //{
            //    UserID = userID,
            //    ClientName = user.UserFullName,
            //    CongDung = TinhCong(userID, Enums.LoaiCong.CongDung),
            //    CongThem = TinhCong(userID, Enums.LoaiCong.CongThem),
            //    CongTre = TinhCong(userID, Enums.LoaiCong.CongTre),
            //    CongPhep = TinhCong(userID, Enums.LoaiCong.CongPhep),
            //    ListAttan = listAtOfUser(userID)           
                
            //});
            return model;
        }

        private IEnumerable<ListAttandanceModel> listAtOfUser(int userID)
        {

           
            var model = db.tbl_Attandance.Where(m => m.UserID == userID).OrderByDescending(m=>m.AtYear).ThenByDescending(m=>m.AtMonth).ThenByDescending(m=>m.AtDay).ToList();
            List<ListAttandanceModel> liAttOfUser = new List<ListAttandanceModel>();
            foreach (var item in model)
            {
                ListAttandanceModel li = new ListAttandanceModel();
                li.CheckIn = item.AtDateCheckIn.Value.ToString("dd/MM/yyyy");
                li.Day = GetDayOfWeek(item.AtYear.Value, item.AtMonth.Value, item.AtDay.Value);
                li.Color = SetColorAtt(item.AtInOrOut.Value);
                li.Status = item.AtInOrOut == 4 ? "Chờ Duyệt" : "Đã Tính";
                li.TimeCheckIn = item.AtTime.Value.ToString("hh:mm:ss");
                liAttOfUser.Add(li);
            }


             return liAttOfUser;
        }

        private string SetColorAtt(int loaicong)
        {
            string result = "default";
            switch ((Enums.LoaiCong)loaicong)
            {
                case Enums.LoaiCong.CongDung:
                    result = "info";
                    break;
                case Enums.LoaiCong.CongPhep:
                    result = "warning";
                    break;
                case Enums.LoaiCong.CongTre:
                    result = "danger";
                    break;
                case Enums.LoaiCong.CongThem:
                    result = "success";
                    break;
                default:
                    result = "default";
                    break;
            }
            return result;
        }

        private string GetDayOfWeek(int year, int month, int day)
        {
            DateTime dt = new DateTime(year, month, day);
            string result = "";
            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    result = "Chủ Nhật";
                    break;
                case DayOfWeek.Monday:
                    result = "Thứ Hai";
                    break;
                case DayOfWeek.Tuesday:
                    result = "Thứ Ba";
                    break;
                case DayOfWeek.Wednesday:
                    result = "Thứ Tư";
                    break;
                case DayOfWeek.Thursday:
                    result = "Thứ Năm";
                    break;
                case DayOfWeek.Friday:
                    result = "Thứ Sáu";
                    break;
                case DayOfWeek.Saturday:
                    result = "Thứ Bảy";
                    break;
                default:
                    break;
            }

            return result;
        }

        public int CheckIn(int UserID)
        {
            var result = new SqlParameter();
            result.ParameterName = "@Result";
            result.Direction = System.Data.ParameterDirection.Output;
            result.SqlDbType = System.Data.SqlDbType.Int;
            try
            {
                
                var kq = db.Database.ExecuteSqlCommand("exec proc_as_UserCheckIn @UserID, @UserNote, @UserEvent, @Result OUT",
                    new SqlParameter("@UserID", UserID),
                    new SqlParameter("@UserNote",GetDayOfWeek(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day)),
                    new SqlParameter("@UserEvent", 1) ,
                    result
                    );
            }
            catch (Exception ex)
            {
                var er = ex.Message;
                return -1;
            }           
            return (int)result.Value;
        }

        public int CheckCongThem(UserEventCreateViewModel modelEvent)
        {
            int result = 0;
            //int loopLength = modelEvent.UeWillExpires.Value.Day - modelEvent.UeDateExpires.Value.Day;

            var fromDate = modelEvent.UeDateExpires.Value;
            var toDate = modelEvent.UeWillExpires.Value;
            int i = 0;
            while (fromDate.Date.AddDays(i) <= toDate.Date)
            {
                var modelAtt = new tbl_Attandance();
                modelAtt.UserID = modelEvent.UserID;
                modelAtt.AtDateCheckIn = fromDate.Date.AddDays(i);
                modelAtt.AtInOrOut = (int)Enums.LoaiCong.ChoDuyet;
                modelAtt.AtMonth = fromDate.Date.AddDays(i).Month;
                modelAtt.AtDay = fromDate.Date.AddDays(i).Day;
                modelAtt.AtYear = fromDate.Date.AddDays(i).Year;
                modelAtt.AtTime = DateTime.Now;
                modelAtt.AtNote = GetDayOfWeek(fromDate.Date.AddDays(i).Year, fromDate.Date.AddDays(i).Month, fromDate.Date.AddDays(i).Day);
                modelAtt.UeID = modelEvent.UeID;

                List<tbl_Attandance> liAtt = CheckDateUnique(fromDate.Date.AddDays(i), modelEvent.UserID.Value);

                if (liAtt.Count() < 1)
                {
                    db.tbl_Attandance.Add(modelAtt);
                    result = db.SaveChanges();
                }
                else
                {
                    result = db.Database.ExecuteSqlCommand("exec proc_as_UpdateAttandaceWithEvent @AtID,@AtInOrOut,@UeID",
                        new SqlParameter("@AtID",liAtt[0].AtID),
                        new SqlParameter("@AtInOrOut", (int)Enums.LoaiCong.ChoDuyet),
                        new SqlParameter("@UeID",modelEvent.UeID));
                }               
                i++;
            }

            return result;
        }

        public List<tbl_Attandance> CheckDateUnique(DateTime input, int UserID)
        {
            return db.tbl_Attandance.Where(m => m.UserID == UserID && DbFunctions.TruncateTime(m.AtDateCheckIn) == input.Date).ToList();
        }

        public DateTime TestAddDayZero()
        {
            DateTime dt = new DateTime(2017, 02, 28);
            return dt.Date.AddDays(1);
        }






        public int TinhCong(int month, int userID, Enums.LoaiCong loaicong)
        {

            return db.tbl_Attandance.Count(m => m.AtMonth == month && m.AtInOrOut.Value == (int)loaicong && m.UserID == userID);
        }


        public SelectList DdlMonth(int currentMonth)
        {
            List<SelectListItem> listItem = new List<SelectListItem>();
            for (int i = 1; i <= 12; i++)
            {
                listItem.Add(new SelectListItem
                {
                    Text = "Tháng " + i,
                    Value = "1",
                });
            }
            return new SelectList(listItem,currentMonth);
        }



    }
}
