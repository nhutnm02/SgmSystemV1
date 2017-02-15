using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAL;
using Model.ViewModel;
using SgmSystemV1.Common;
using System.Web.Security;

namespace SgmSystemV1.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel userVm)
        {
            if (ModelState.IsValid)
            {
                var dao = new UsersDAL();
               
                var result = dao.Login(userVm);

                if (result)
                {
                    var user = dao.GetUser(userVm.UserName);
                    //var userInfo = new UserLogin();
                    //userInfo.UserID = user.UserID;
                    //userInfo.UserName = user.UserName;
                    Session[CommonConstants.USER_ID] = new UserLogin()
                    {
                        UserID = user.UserID,
                        UserName = user.UserName

                    };

                    Session.Add(CommonConstants.USER_NAME, user.UserName);
                    Session.Add(CommonConstants.USER_ID, user.UserID);
                    Session.Add(CommonConstants.USER_COM, user.UserComputer);
                    CommonConstants.USERID = user.UserID;

                   TempData["com"] = CommonConstants.USERID;


                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng.");
                }
            }

            return View("Login");
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