using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModel.Admin;
using System.Web.Security;
using Model.DAL.Admin;

namespace SgmSystemV1.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        AccountDAL accDAL = null;

        // GET: Admin/Account
        public AccountController()
        {
            accDAL = new AccountDAL();
        }

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Login()
        {
            LoginAdminViewModel model = new LoginAdminViewModel();
            return View("Login",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginAdminViewModel model)
        {
            if (ModelState.IsValid) {
                if (accDAL.Login(model)){
                    Session.Add("ADMIN_NAME",model.AdminName);
                    Session.Add("ADMIN_ID", model.AdminID);
                    TempData["Admin"] = model.AdminName.ToString();
                    FormsAuthentication.SetAuthCookie(model.AdminName, false);
                    return RedirectToAction("Index", "Home", new {Area = "Admin"});
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
                }

                
            }            
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Login", "Account");
        }
    }
}