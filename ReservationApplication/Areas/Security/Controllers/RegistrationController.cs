using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.Security
{
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
        public ActionResult Create(USERS user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.Insert(user);
                    TempData["Msg"] = "A regisztráció sikeres";
                    return RedirectToAction("Index");
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