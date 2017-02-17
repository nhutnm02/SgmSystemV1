using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.DAL
{
    public class UsersDAL
    {
        SgmSystemDbContext db = null;

        public UsersDAL()
        {
            db = new SgmSystemDbContext();
        }

        public IEnumerable<UsersListViewModel> GetListForClient()
        {
            GroupDAL groupDAL = new GroupDAL();

            List<UsersListViewModel> liUser = new List<UsersListViewModel>();
            var modelUser = db.tbl_Users.ToList();

            foreach (var item in modelUser)
            {
                UsersListViewModel model = new UsersListViewModel();
                model.UserID = item.UserID;
                model.GroupName = groupDAL.GetGroupByID(item.GroupID).GroupName;
                model.UserName = item.UserName;
                model.UserFullName = item.UserFullName;
                model.UserDOB = item.UserDOB.Value;
                model.UserEmail = item.UserEmail;
                model.UserPhone = item.UserPhone;
                model.UserExtention = item.UserExtention;
                model.UserJoinDate = item.UserJoinDate;
                model.UserComputer = item.UserComputer;
                model.UserCreateDate = item.UserCreateDate;
                model.UserStatus = item.UserStatus == true;
                model.Color = item.UserStatus == true ? "default" : "danger";
                model.UserAddress = item.UserAddress;

                liUser.Add(model);
            }

            return liUser;
        }

        public tbl_Users GetUser(string userName)
        {
            return db.tbl_Users.SingleOrDefault(x => x.UserName == userName);
        }

        public tbl_Users GetUser(int? id)
        {
            return db.tbl_Users.SingleOrDefault(x => x.UserID == id);
        }

        public long CreateUser(UserCreateViewModel userModel)
        {
            try
            {
                var tbl_Users = new tbl_Users();
                tbl_Users.GroupID = userModel.GroupID;
                tbl_Users.UserFullName = userModel.UserFullName;
                tbl_Users.UserEmail = userModel.UserEmail;
                tbl_Users.UserPass = userModel.UserPass;
                tbl_Users.UserPhone = userModel.UserPhone;
                tbl_Users.UserCreateDate = DateTime.Now;
                tbl_Users.UserDOB = userModel.UserDOB;
                tbl_Users.UserExtention = userModel.UserExtention;
                tbl_Users.UserName = userModel.UserName;
                tbl_Users.UserJoinDate = userModel.UserJoinDate;
                tbl_Users.UserStatus = userModel.UserStatus;
                tbl_Users.UserComputer = userModel.UserComputer;
                tbl_Users.UserAddress = userModel.UserAddress;


                db.tbl_Users.Add(tbl_Users);
                var result = db.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
         
        }

        public long EditUsers(UserEditViewModel userEditViewModel)
        {
            var model = db.tbl_Users.Find(userEditViewModel.UserID);
            model.UserFullName = userEditViewModel.UserFullName;
            model.UserName = userEditViewModel.UserName;
            model.UserPass = userEditViewModel.UserPass;
            model.UserPhone = userEditViewModel.UserPhone;
            model.UserEmail = userEditViewModel.UserEmail;
            model.UserDOB = userEditViewModel.UserDOB;
            model.UserComputer = userEditViewModel.UserComputer;
            model.UserExtention = userEditViewModel.UserExtention;
            model.UserStatus = userEditViewModel.UserStatus;
            model.UserAddress = userEditViewModel.UserAddress;
            db.Entry(model).State = EntityState.Modified;
            return db.SaveChanges();
        }

        public UserEditViewModel SelectUserByID(int ID)
        {
            var userID = ID;
            GroupDAL groupDAL = new GroupDAL();
            var listUser = db.tbl_Users.SingleOrDefault(m => m.UserID == userID);

            var model = new UserEditViewModel();

            model.UserID = listUser.UserID;
            model.UserName = listUser.UserName;
            model.UserPass = listUser.UserPass;
            model.UserFullName = listUser.UserFullName;
            model.UserComputer = listUser.UserComputer;
            model.UserDOB = listUser.UserDOB;
            model.UserEmail = listUser.UserEmail;
            model.GroupID = listUser.GroupID;
            model.UserExtention = listUser.UserExtention;
            model.UserJoinDate = listUser.UserJoinDate;
            model.UserPhone = listUser.UserPhone;
            model.UserStatus = listUser.UserStatus;
            model.DdlGroupID = groupDAL.DdlGroup(listUser.GroupID);
            model.UserAddress = listUser.UserAddress;           
            return model;
        }

        public bool Login(UserLoginViewModel userVM)
        {
            var result = db.tbl_Users.Count(m=>m.UserName == userVM.UserName && m.UserPass == userVM.Password && m.UserStatus == true);
            if(result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }








    }
}
