using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.User.Controllers
{
    [Authorize(Roles = "A, U")]
    public class AppointmentsHistoryController : Controller
    {
        const double DATAPERPAGE = 10;
        private UserBL objBS;

        public AppointmentsHistoryController()
        {
            objBS = new UserBL();
        }

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

            TempData["userappointments"] = appointments;
            return View();
        }
    }
}