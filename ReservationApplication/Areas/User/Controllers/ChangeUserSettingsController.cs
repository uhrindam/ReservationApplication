using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ReservationApplication.Areas.User.Controllers
{
    [Authorize(Roles = "A, U")]
    public class ChangeUserSettingsController : Controller
    {
        private UserBL objBs;

        public ChangeUserSettingsController()
        {
            objBs = new UserBL();
        }

        // GET: User/ChangeUserSettings
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Change(UserRegistration user)
        {
            try
            {
                USERS originalUser = objBs.GetByID(User.Identity.Name);
                originalUser.Passwd = UserBL.Hash(user.Passwd);
                originalUser.EmailAddress = user.EmailAddress;

                objBs.Update(originalUser);
                FormsAuthentication.SignOut();

                return RedirectToAction("Index", "Login", new { area = "Security", afterRegistration = "A felhasználói adatok változatása megtörtént. Kerlek jelentkezz be újra!"});
            }
            catch
            {
                TempData["Msg"] = "A felhasználói adatok megváltoztatása sikertelen.";
                return RedirectToAction("Index");
            }
        }
    }
}