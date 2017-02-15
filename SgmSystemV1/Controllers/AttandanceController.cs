using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAL;
using Model.ViewModel;
using SgmSystemV1.Common;

namespace SgmSystemV1.Controllers
{
    [Authorize]
    public class AttandanceController : Controller
    {
        AttandanceDAL atDAL = null;
        public AttandanceController()
        {
            atDAL = new AttandanceDAL();
        }

        [Authorize]
        // GET: Attandance
        public ActionResult AtIndex()
        {

            //return View("AtIndex",atDAL.ListAllOfUser(int.Parse(Session["UserID"].ToString())));
            return View("AtIndex",atDAL.ListAllOfUser(int.Parse(Session[CommonConstants.USER_ID].ToString())));
        }

        [HttpPost]
        public ActionResult AtCheckIn()
        {

            var attanceDao = new AttandanceDAL();
            int userID = int.Parse(Session[CommonConstants.USER_ID].ToString());

            var resultAttan = attanceDao.CheckIn(userID);

            if (resultAttan == 1)
            {
                TempData["msg"] = "Điểm Danh Thành Công";
                Session.Add(CommonConstants.CHECKED, "checked");
            }

            return View("AtIndex", atDAL.ListAllOfUser(userID));
        }

        
    }
}