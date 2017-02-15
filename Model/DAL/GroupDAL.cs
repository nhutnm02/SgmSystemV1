using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Helper;
using Model.ViewModel;
using System.Web.Mvc;

namespace Model.DAL
{
    public class GroupDAL
    {
        SgmSystemDbContext db = null;
        public GroupDAL()
        {
            db = new SgmSystemDbContext();
        }

        public tbl_Group GetGroupByID(int GroupID)
        {
            return db.tbl_Group.SingleOrDefault(m => m.GroupID == GroupID);
        }

        public SelectList DdlGroup(int groupId = 0)
        {
            return new SelectList(db.tbl_Group.Where(m => m.GroupStatus == true), "GroupID", "GroupName",groupId);
        }
    }
}
