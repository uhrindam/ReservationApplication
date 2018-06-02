using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReservationApplication.Areas.Admin.Controllers
{
    public class ManageCategoriesController : Controller
    {
        const double DATAPERPAGE = 10;
        private CategoryBL objBS;

        public ManageCategoriesController()
        {
            objBS = new CategoryBL();
        }

        // GET: Admin/ManageCategories
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var users = objBS.GetAll();

            #region Sort
            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Price":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.Price).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.Price).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "ProcessLengthInMunites":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.ProcessLengthInMunites).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.ProcessLengthInMunites).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    users = users.OrderBy(x => x.CategoryName).ToList();
                    break;
            }
            #endregion

            ViewBag.TotalPages = Math.Ceiling(users.Count() / DATAPERPAGE);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            users = users.Skip((page - 1) * (int)DATAPERPAGE).Take((int)DATAPERPAGE);

            return View(users);
        }

        public ActionResult Delete(string id)
        {
            try
            {

                objBS.Delete(id);
                TempData["Msg"] = "A törlés sikeres";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Msg"] = "A törlés sikertelen";
                return RedirectToAction("Index");
            }
        }
    }
}