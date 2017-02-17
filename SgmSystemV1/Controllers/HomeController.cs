using Model.DAL;
using Model.Helper;
using Model.ViewModel;
using SgmSystemV1.Common;
using SgmSystemV1.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SgmSystemV1.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        HomeDAL homeDao = null;
        public HomeController()
        {
            homeDao = new HomeDAL();
        }
        public ActionResult Index()
        {
            UserEventDAL userDao = new UserEventDAL();
            var userCom = Session[CommonConstants.USER_COM] == null ? "no" : Session[CommonConstants.USER_COM].ToString();
            var systemCom = Dns.GetHostEntry(Request.ServerVariables["REMOTE_ADDR"]).HostName.ToString();

            bool resultCom = homeDao.CheckUserCom(userCom, systemCom);
            bool resultCheckedIn = Session[CommonConstants.CHECKED] == null ? true : false;

            HomeViewModel model = new HomeViewModel();
            model.IsHideButtonByComName = resultCom && resultCheckedIn;
            model.ListUserForHome = userDao.UeListAllHome();

            return View("Index",model);
        }

        public ActionResult WaitForUpdate()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}