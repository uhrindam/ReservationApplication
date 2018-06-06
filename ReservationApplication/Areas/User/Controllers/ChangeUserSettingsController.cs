using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.User.Controllers
{
    [Authorize(Roles = "A, U")]
    public class ChangeUserSettingsController : Controller
    {
        // GET: User/ChangeUserSettings
        public ActionResult Index()
        {
            return View();
        }
    }
}