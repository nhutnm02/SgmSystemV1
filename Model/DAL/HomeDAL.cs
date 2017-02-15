using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAL
{
    public class HomeDAL
    {
        SgmSystemDbContext db = null;
        public HomeDAL()
        {
            db = new SgmSystemDbContext();
        }

        public bool CheckUserCom(string userCom, string systemCom)
        {   

            return userCom.ToLower().Equals(systemCom.ToLower()) ? true : false;
        }





    }
}
