using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.Security
{
    [AllowAnonymous]
    public class RegistrationController : Controller
    {
        private UserBL objBs;

        public RegistrationController()
        {
            objBs = new UserBL();
        }

        // GET: Security/Registration
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// If The user given all of the data correctly, the registration is complete. After that, the the user can login in the login page.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(UserRegistration user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.Insert(user);
                    return RedirectToAction("Index", "Login", new { afterRegistration = "A regisztráció sikeres!" });

                }
                return View("Index");
            }
            catch
            {
                TempData["Msg"] = "A regisztráció sikertelen";
                return RedirectToAction("Index");
            }
        }
    }
}