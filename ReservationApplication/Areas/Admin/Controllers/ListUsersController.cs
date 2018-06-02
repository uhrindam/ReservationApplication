﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.Admin.Controllers
{
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

            users = users.Skip((page -1) * (int)DATAPERPAGE).Take((int)DATAPERPAGE);

            return View(users);
        }
    }
}