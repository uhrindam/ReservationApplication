using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.Admin.Controllers
{
    [Authorize(Roles = "A")]
    public class ListUsersController : Controller
    {
        const double DATAPERPAGE = 10;
        private UserBL objBS;

        public ListUsersController()
        {
            objBS = new UserBL();
        }

        // GET: Admin/ListUsers
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var users = objBS.GetAll();

            #region Sort
            switch (SortBy)
            {
                case "NickName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.NickName).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.NickName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "FullName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.FullName).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.FullName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "EmailAddress":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.EmailAddress).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.EmailAddress).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "RegistrationDate":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.RegistrationDate).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.RegistrationDate).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    users = users.OrderBy(x => x.NickName).ToList();
                    break;
            }
            #endregion

            ViewBag.TotalPages = Math.Ceiling(users.Count() / DATAPERPAGE);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            users = users.Skip((page - 1) * (int)DATAPERPAGE).Take((int)DATAPERPAGE);

            return View(users);
        }

        public ActionResult Details(string NickName, string SortOrder, string SortBy, string Page, string ISortOrder, string ISortBy, int IPage)
        {
            ViewBag.NickName = NickName;
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            ViewBag.ISortOrder = ISortOrder;
            ViewBag.ISortBy = ISortBy;
            ViewBag.IPage = IPage;

            var appointments = objBS.GetAll().Where(x => x.NickName == NickName).First().APPOINTMENTS.ToList();

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
                    appointments = appointments.OrderBy(x => x.NickName).ToList();
                    break;
            }
            #endregion


            ViewBag.TotalPages = Math.Ceiling(appointments.Count() / DATAPERPAGE);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            appointments = appointments.Skip((page - 1) * (int)DATAPERPAGE).Take((int)DATAPERPAGE).ToList();

            TempData["userappointments"] = appointments;
            return View("Details");
        }

        public ActionResult Back(string ISortOrder, string ISortBy, int IPage)
        {
            return RedirectToAction("Index", new { SortOrder = ISortOrder, SortBy = ISortBy, Page = IPage });
        }
    }
}