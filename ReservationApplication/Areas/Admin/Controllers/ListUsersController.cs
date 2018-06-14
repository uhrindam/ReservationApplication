using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.Admin.Controllers
{
    /// <summary>
    /// This controller prepares the data to ListUsers.
    /// </summary>
    [Authorize(Roles = "A")]
    public class ListUsersController : Controller
    {
        /// <summary>
        /// This number is the limit of the presented users in one page.
        /// </summary>
        const double DATAPERPAGE = 10;
        private UserBL objBS;

        public ListUsersController()
        {
            objBS = new UserBL();
        }

        /// <summary>
        /// This method is prepars the data in right sorting, and in the right page.
        /// </summary>
        /// <param name="SortOrder">The direction of the sorting</param>
        /// <param name="SortBy">The property of the sorting</param>
        /// <param name="Page">The number of the actual page</param>
        /// <returns></returns>
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

            //I have to count to number of total pages, based on the element\page. After that, I count the number of actuall page, and I take the right elements of the list.
            ViewBag.TotalPages = Math.Ceiling(users.Count() / DATAPERPAGE);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            users = users.Skip((page - 1) * (int)DATAPERPAGE).Take((int)DATAPERPAGE);

            return View(users);
        }

        /// <summary>
        /// This method provide the data to the Dateils page, which is shows the users appointemnts. 
        /// In this page, the users can go back to the index page. When the user is want to go back to the index page,
        /// the parameters will be the same. (SortOrder, Sortby...)
        /// </summary>
        /// <param name="NickName"></param>
        /// <param name="SortOrder"></param>
        /// <param name="SortBy"></param>
        /// <param name="Page"></param>
        /// <param name="ISortOrder"></param>
        /// <param name="ISortBy"></param>
        /// <param name="IPage"></param>
        /// <returns></returns>
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