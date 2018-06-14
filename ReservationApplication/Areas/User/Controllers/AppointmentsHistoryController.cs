using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.User.Controllers
{
    /// <summary>
    /// The users could get information from their former appointments, and they can delete active appointments here.
    /// </summary>
    [Authorize(Roles = "A, U")]
    public class AppointmentsHistoryController : Controller
    {
        const double DATAPERPAGE = 10;
        private UserBL objBS;

        public AppointmentsHistoryController()
        {
            objBS = new UserBL();
        }

        /// <summary>
        /// The sorting, and the pagenition is the same as that was in ListUsers for example.
        /// </summary>
        /// <param name="SortOrder"></param>
        /// <param name="SortBy"></param>
        /// <param name="Page"></param>
        /// <returns></returns>
        // GET: User/AppointmentsHistory
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var appointments = objBS.GetAll().Where(x => x.NickName == User.Identity.Name).First().APPOINTMENTS.ToList();

            #region Sort
            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            appointments = appointments.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            appointments = appointments.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "ReservationDate":
                    switch (SortOrder)
                    {
                        case "Asc":
                            appointments = appointments.OrderBy(x => x.ReservationDate).ToList();
                            break;
                        case "Desc":
                            appointments = appointments.OrderByDescending(x => x.ReservationDate).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "CurrentPrice":
                    switch (SortOrder)
                    {
                        case "Asc":
                            appointments = appointments.OrderBy(x => x.CurrentPrice).ToList();
                            break;
                        case "Desc":
                            appointments = appointments.OrderByDescending(x => x.CurrentPrice).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "StartDate":
                    switch (SortOrder)
                    {
                        case "Asc":
                            appointments = appointments.OrderBy(x => x.StartDate).ToList();
                            break;
                        case "Desc":
                            appointments = appointments.OrderByDescending(x => x.StartDate).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "EndDate":
                    switch (SortOrder)
                    {
                        case "Asc":
                            appointments = appointments.OrderBy(x => x.EndDate).ToList();
                            break;
                        case "Desc":
                            appointments = appointments.OrderByDescending(x => x.EndDate).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    appointments = appointments.OrderBy(x => x.StartDate).ToList();
                    break;
            }
            #endregion


            ViewBag.TotalPages = Math.Ceiling(appointments.Count() / DATAPERPAGE);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            appointments = appointments.Skip((page - 1) * (int)DATAPERPAGE).Take((int)DATAPERPAGE).ToList();

            TempData["userappointments"] = appointments;
            return View();
        }

        /// <summary>
        /// THe user can delete active appointments.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(string id)
        {
            AppointmentBL appointmentBL = new AppointmentBL();
            try
            {
                appointmentBL.Delete(int.Parse(id));
                TempData["MsgS"] = "A törlés sikeres";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["MsgU"] = "A törlés sikertelen";
                return RedirectToAction("Index");
            }
        }
    }
}