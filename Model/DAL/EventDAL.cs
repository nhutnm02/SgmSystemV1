using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model.DAL
{
    public class EventDAL
    {
        SgmSystemDbContext db = null;
        public EventDAL()
        {
            db = new SgmSystemDbContext();
        }

        public SelectList DdlEvent()
        {
            return new SelectList(db.tbl_Event.ToList(), "EventID", "EventName");
        }


    }
}
