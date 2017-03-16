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
            UsersDAL userDAL = new UsersDAL();
            var modelUser = userDAL.GetUser(User.Identity.Name);
            //return View("AtIndex",atDAL.ListAllOfUser(int.Parse(Session["UserID"].ToString())));
            return View("AtIndex",atDAL.ListAllOfUser(modelUser.UserID));
        }

        [HttpPost]
        public ActionResult AtCheckIn()
        {

            var attanceDao = new AttandanceDAL();
            UsersDAL userDAL = new UsersDAL();
            var modelUser = userDAL.GetUser(User.Identity.Name);
            int userID = modelUser.UserID;
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