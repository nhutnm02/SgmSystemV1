using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModel;
using Model.ViewModel.Admin;

namespace Model.DAL.Admin
{
    public class AccountDAL
    {
        SgmSystemDbContext db = null;

        public AccountDAL()
        {
            db = new SgmSystemDbContext();
        }

        public tbl_Admin GetAdminById(int id)
        {
            return db.tbl_Admin.SingleOrDefault(m => m.AdminID == id);
        }

        public bool Login(LoginAdminViewModel model)
        {
            var result = db.tbl_Admin.Where(m => m.AdminName == model.AdminName && m.AdminPass == model.AdminPass).Count();

            if (result > 0)
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
