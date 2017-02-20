using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.ViewModel;
using Model.DAL;
using SgmSystemV1.Common;

namespace SgmSystemV1.Controllers
{
    [Authorize]
    public class UserEventController : Controller
    {
        UserEventDAL ueDAL = null;
        public UserEventController()
        {
            ueDAL = new UserEventDAL();
        }
        // GET: UserEvent
        public ActionResult Index()
        {
            UsersDAL userDAL = new UsersDAL();
            var modelUser = userDAL.GetUser(User.Identity.Name);
            return View("Index", ueDAL.UeListAllByUser(1, modelUser.UserID));
        }

        public ActionResult IndexPhep()
        {
            UsersDAL userDAL = new UsersDAL();
            var modelUser = userDAL.GetUser(User.Identity.Name);
            return View("IndexPhep", ueDAL.UeListAllByUser(2, modelUser.UserID));
        }

        // GET: UserEvent/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserEvent/Create
        public ActionResult Create()
        {

            UserEventCreateViewModel model = new UserEventCreateViewModel();
            return View("Create", model);
        }

        // POST: UserEvent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserEventCreateViewModel createModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(createModel);
                }

                UsersDAL userDAL = new UsersDAL();
                var modelUser = userDAL.GetUser(User.Identity.Name);

                createModel.UserID = modelUser.UserID;
                createModel.UeType = 1;
                createModel.EventID = 1;
                var result = ueDAL.CreateUserEvent(createModel);
                if (result < 1)
                {
                    switch (result)
                    {
                        case -1:
                            ModelState.AddModelError("Message", "Ngày bắt đầu không được lớn hơn ngày kết thúc!");
                            break;
                        case -2:
                            ModelState.AddModelError("Message", "Bạn đã đăng ký nghỉ thời gian này!");
                            break;
                        default:
                            ModelState.AddModelError("Message", "Đã có lỗi xảy ra, hãy liên hệ IT!");
                            break;
                    }
                    return View(createModel);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Message", ex.Message);
                return View();
            }
        }

        public ActionResult CreatePhep()
        {
            UserEventCreateViewModel model = new UserEventCreateViewModel();
            return View("CreatePhep", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePhep(UserEventCreateViewModel createPhepModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(createPhepModel);
                }

                UsersDAL userDAL = new UsersDAL();
                var modelUser = userDAL.GetUser(User.Identity.Name);

                createPhepModel.UserID = modelUser.UserID;
                createPhepModel.UeType = 2;
                createPhepModel.EventID = 1;
                var result = ueDAL.CreateUserEvent(createPhepModel);
                if (result < 1)
                {
                    switch (result)
                    {
                        case -1:
                            ModelState.AddModelError("Message", "Ngày bắt đầu không được lớn hơn ngày kết thúc!");
                            break;
                        case -2:
                            ModelState.AddModelError("Message", "Bạn đã đăng ký nghỉ thời gian này!");
                            break;
                        default:
                            ModelState.AddModelError("Message", "Đã có lỗi xảy ra, hãy liên hệ IT!");
                            break;
                    }               
                    return View(createPhepModel);
                }

                ModelState.Clear();
                return RedirectToAction("IndexPhep");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Message", ex.Message);
                return View();
            }
        }

        // GET: UserEvent/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: UserEvent/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: UserEvent/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserEvent/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (!ModelState.IsValid)
                {
                    return View();
                }

                UsersDAL userDAL = new UsersDAL();
                var modelUser = userDAL.GetUser(User.Identity.Name);
                ueDAL.DeleteUserEventAndAttandanceById(id);

                return RedirectToAction("Index","UserEvent", ueDAL.UeListAllByUser(1, modelUser.UserID));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeletePhep(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (!ModelState.IsValid)
                {
                    return View();
                }
                UsersDAL userDAL = new UsersDAL();
                var modelUser = userDAL.GetUser(User.Identity.Name);

                ueDAL.DeleteUserEventAndAttandanceById(id);

                return RedirectToAction("IndexPhep", ueDAL.UeListAllByUser(2, modelUser.UserID));
            }
            catch
            {
                return View();
            }
        }
    }
}
