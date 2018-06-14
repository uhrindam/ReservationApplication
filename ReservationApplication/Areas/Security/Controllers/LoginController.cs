using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ReservationApplication.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Security/Login
        public ActionResult Index(string afterRegistration)
        {
            if (afterRegistration != null)
                TempData["Msg"] = afterRegistration;
            return View();
        }

        /// <summary>
        /// If the user is exist in the database, then the login is clompeletd.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="stayin"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SignIn(USERS user, bool stayin)
        {
            if(Membership.ValidateUser(user.NickName, user.Passwd))
            {
                FormsAuthentication.SetAuthCookie(user.NickName, stayin ? true : false);
                return RedirectToAction("Index", "Home", new { area = "Common"});
            }
            else
            {
                TempData["Msg"] = "A bejelentkezés sikertelen";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// This option is displayd only when there is an authenticated user.
        /// </summary>
        /// <returns></returns>
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common"});
        }
    }
}