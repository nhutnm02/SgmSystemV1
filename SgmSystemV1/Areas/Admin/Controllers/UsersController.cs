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
    public class UsersController : Controller
    {
        UsersDAL userDAL = null;
        public UsersController()
        {
            userDAL = new UsersDAL();
        }
        [Authorize]
        // GET: Admin/Users
        public ActionResult Index()
        {   
            
                        
            return View("Index",userDAL.GetListForClient());
        }

        public ActionResult Create()
        {

            UserCreateViewModel model = new UserCreateViewModel();
            GroupDAL groupDAL = new GroupDAL();
            model.DdlGroupID = groupDAL.DdlGroup();
            return View("Create",model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserCreateViewModel userCreateViewModel)
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    GroupDAL groupDAL = new GroupDAL();
                    userCreateViewModel.DdlGroupID = groupDAL.DdlGroup();
                    return View(userCreateViewModel);
                }

                userDAL.CreateUser(userCreateViewModel);
                return RedirectToAction("Index", "Users", new { area = "Admin" });
            }
            catch(Exception ex)
            {
                GroupDAL groupDAL = new GroupDAL();
                userCreateViewModel.DdlGroupID = groupDAL.DdlGroup();
                ModelState.AddModelError("", ex.Message);
                return View();
            }
           
        }

        public ActionResult Edit(int id)
        {

            return View("Edit", userDAL.SelectUserByID(id));
        }

        [HttpPost]
        public ActionResult Edit(UserEditViewModel userEditViewModel)
        {
            try
            {
                var model = userDAL.SelectUserByID(userEditViewModel.UserID);
                userEditViewModel.UserPass = model.UserPass;
                if(model == null)
                {
                    return HttpNotFound();
                }
                if (!ModelState.IsValid)
                {
                    return View(userEditViewModel);
                }

                if ((userDAL.EditUsers(userEditViewModel) < 1))
                {
                    ModelState.AddModelError("", "Đã có lỗi xảy ra!");
                    return View(userEditViewModel);
                }

                return RedirectToAction("Index", "Users", new { area = "Admin" });
            }
            catch (Exception ex)
            {

                string mes = ex.Message;
                return View(userEditViewModel);
            }
          
        }


    }
}