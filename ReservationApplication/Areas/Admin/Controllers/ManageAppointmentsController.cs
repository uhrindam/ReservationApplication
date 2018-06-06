using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ManageAppointmentsController : Controller
    {
        // GET: Admin/ManageAppointments
        public ActionResult Index()
        {
            return View();
        }
    }
}