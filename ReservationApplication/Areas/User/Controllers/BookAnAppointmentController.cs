using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.User.Controllers
{
    public class BookAnAppointmentController : Controller
    {
        // GET: User/BookAnAppointment
        public ActionResult Index()
        {
            return View();
        }
    }
}