using BLL;
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
        const double DATAPERPAGE = 10;
        private AppointmentBL objBS;

        public ManageAppointmentsController()
        {
            objBS = new AppointmentBL();
        }

        // GET: Admin/ManageAppointments
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {

            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;

            var appointments = objBS.GetAll().ToList();

            #region Sort
            switch (SortBy)
            {
                case "ID":
                    switch (SortOrder)
                    {
                        case "Asc":
                            appointments = appointments.OrderBy(x => x.ID).ToList();
                            break;
                        case "Desc":
                            appointments = appointments.OrderByDescending(x => x.ID).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "FullName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            appointments = appointments.OrderBy(x => x.USERS.FullName).ToList();
                            break;
                        case "Desc":
                            appointments = appointments.OrderByDescending(x => x.USERS.FullName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
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
                case "StartingPont":
                    switch (SortOrder)
                    {
                        case "Asc":
                            appointments = appointments.OrderBy(x => x.StartingPont).ToList();
                            break;
                        case "Desc":
                            appointments = appointments.OrderByDescending(x => x.StartingPont).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "EndingPoint":
                    switch (SortOrder)
                    {
                        case "Asc":
                            appointments = appointments.OrderBy(x => x.EndingPoint).ToList();
                            break;
                        case "Desc":
                            appointments = appointments.OrderByDescending(x => x.EndingPoint).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    appointments = appointments.OrderBy(x => x.StartingPont).ToList();
                    break;
            }
            #endregion


            ViewBag.TotalPages = Math.Ceiling(appointments.Count() / DATAPERPAGE);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            appointments = appointments.Skip((page - 1) * (int)DATAPERPAGE).Take((int)DATAPERPAGE).ToList();

            return View(appointments);
        }
    }
}