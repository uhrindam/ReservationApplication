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
    public class ManageCategoriesController : Controller
    {
        const double DATAPERPAGE = 10;
        private CategoryBL objBS;

        public ManageCategoriesController()
        {
            objBS = new CategoryBL();
        }

        // GET: Admin/ManageCategories
        public ActionResult Index(string SortOrder, string SortBy, string Page, string afterCreateCageory)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            ViewBag.afterCreateCageory = afterCreateCageory;
            var categories = objBS.GetAll();

            #region Sort
            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "Price":
                    switch (SortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.Price).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.Price).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                case "ProcessLengthInMunites":
                    switch (SortOrder)
                    {
                        case "Asc":
                            categories = categories.OrderBy(x => x.ProcessLengthInMunites).ToList();
                            break;
                        case "Desc":
                            categories = categories.OrderByDescending(x => x.ProcessLengthInMunites).ToList();
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    categories = categories.OrderBy(x => x.CategoryName).ToList();
                    break;
            }
            #endregion

            ViewBag.TotalPages = Math.Ceiling(categories.Count() / DATAPERPAGE);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            categories = categories.Skip((page - 1) * (int)DATAPERPAGE).Take((int)DATAPERPAGE);

            return View(categories);
        }

        public ActionResult Delete(string id)
        {
            try
            {
                objBS.Delete(id);
                TempData["MsgS"] = "A törlés sikeres";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["MsgU"] = "A törlés sikertelen";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string id)
        {
            return null;
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult CreateCategory(CATEGORIES category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBS.Insert(category);
                    return RedirectToAction("Index", new { afterCreateCageory = category.CategoryName + " kategória sikeresen létrehozva!" });
                }
                return View("Create");
            }
            catch
            {
                TempData["Msg"] = "A kategória létrehozása sikertelen";
                return RedirectToAction("Create");
            }
        }
    }
}