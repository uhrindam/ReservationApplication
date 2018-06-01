using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.Admin.Controllers
{
    public class ListUsersController : Controller
    {
        private UserBS objBS;

        public ListUsersController()
        {
            objBS = new UserBS();
        }

        // GET: Admin/ListUsers
        public ActionResult Index()
        {
            var users = objBS.GetAll();
            return View(users);
        }
    }
}