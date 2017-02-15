using Model.DAL;
using Model.ViewModel;
using SgmSystemV1.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SgmSystemV1.Areas.Admin.Controllers
{
    [AreaAuthorize("Admin")]
    public class HomeController : Controller
    {
        UserEventDAL userDAL = null;
        public HomeController()
        {
            userDAL = new UserEventDAL();
        }
        // GET: Admin/Home
        public ActionResult Index()
        {
            
            return View("Index",userDAL.UeListAllForAdmin());
        }

        public ActionResult Accept(UserEventAdminListViewModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                userDAL.AcceptEvent(model);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
            
        }
    }
}