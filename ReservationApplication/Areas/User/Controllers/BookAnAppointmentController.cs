using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Kendo.Mvc;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using BLL;
using ReservationApplication.Areas.User.Models;

namespace ReservationApplication.Areas.User.Controllers
{
    /// <summary>
    /// Here the users can book an appointment.
    /// </summary>
    [Authorize(Roles = "A, U")]
    public class BookAnAppointmentController : Controller
    {
        AppointmentBL appBL;
        CategoryBL categBL;

        List<SchedulerReservations> reservations;

        public BookAnAppointmentController()
        {
            appBL = new AppointmentBL();
            categBL = new CategoryBL();
            reservations = new List<SchedulerReservations>();
        }

        /// <summary>
        /// I store the categories in the viewbag to farther process.
        /// </summary>
        /// <returns></returns>
        // GET: User/BookAnAppointment
        public ActionResult Index()
        {
            ViewBag.Categories = categBL.GetAll().OrderBy(x => x.CategoryName).ToList();
            return View();
        }

        /// <summary>
        /// In this method I use the classconverter class, which can convert a APPOINTMENTS (DbSet) object to SchedulerReservations object.
        /// This SchedulerReservations object is implemented the ISchedulerEvent interface, which is needed to the Kendo Scheduler.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public virtual JsonResult Read([DataSourceRequest] DataSourceRequest request)
        {
            reservations = ClassConverter.ClassConverter.ConvertToSchedulerReservation(appBL.GetAll().ToList());
            return Json(reservations.ToDataSourceResult(request));
        }

        /// <summary>
        /// If a user create an appointment, I check the model first, then i check a few things. Form example, 
        /// I check the overlapping, check the start, and end dates. If this method is returnd, i check the message: if the message is emtpty, then
        /// the appointment is valid, so I insert it to the database, else I give an alert message.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="appointment"></param>
        /// <returns></returns>
        public virtual ActionResult Create([DataSourceRequest] DataSourceRequest request, SchedulerReservations appointment)
        {
            if (ModelState.IsValid)
            {
                appointment.NickName = User.Identity.Name;
                appointment = ClassConverter.ClassConverter.DataConverter(appointment);

                string message = ClassConverter.ClassConverter.ReservationValidation(appointment);
                if (message == string.Empty)
                {
                    reservations.Add(appointment);
                    ClassConverter.ClassConverter.ConvertToInsertAppointment(appointment);
                }
                else
                {
                    appointment = null;
                    TempData["Message"] = message;
                    ModelState.AddModelError("redirectNeeded", "The user needs to be redirected");
                    return Json(reservations.ToDataSourceResult(request, ModelState));
                }
            }
            return Json(new[] { appointment }.ToDataSourceResult(request, ModelState));
        }
    }
}
