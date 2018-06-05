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

        [HttpPost]
        public ActionResult Create(USERSvalidation user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.Insert(user);
                    return RedirectToAction("Index","Login", new { afterRegistration = "A regisztráció sikeres!" } );
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