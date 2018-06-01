using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.Security
{
    public class RegistrationController : Controller
    {
        // GET: Security/Registration
        public ActionResult Index()
        {
            return View();
        }
    }
}