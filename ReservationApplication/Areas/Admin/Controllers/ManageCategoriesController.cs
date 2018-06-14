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
    /// This controller prepares the data to ManageCategories.
    /// </summary>
    [Authorize(Roles = "A")]
    public class ManageCategoriesController : Controller
    {
        const double DATAPERPAGE = 10;
        private CategoryBL objBS;
        List<CATEGORIES> categories;

        public ManageCategoriesController()
        {
            objBS = new CategoryBL();
            categories = objBS.GetAll().ToList(); ;
        }

        /// <summary>
        /// This method is preper the data to the views. Here I sorting, and "paging" the data.
        /// </summary>
        /// <param name="SortOrder"></param>
        /// <param name="SortBy"></param>
        /// <param name="Page"></param>
        /// <param name="afterCreateCageory"></param>
        private void PrepareData(string SortOrder, string SortBy, string Page, string afterCreateCageory)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            ViewBag.afterCreateCageory = afterCreateCageory;

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

            //I have to count to number of total pages, based on the element\page. After that, I count the number of actuall page, and I take the right elements of the list.
            ViewBag.TotalPages = Math.Ceiling(categories.Count() / DATAPERPAGE);
            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;

            categories = categories.Skip((page - 1) * (int)DATAPERPAGE).Take((int)DATAPERPAGE).ToList();

        }

        // GET: Admin/ManageCategories
        public ActionResult Index(string SortOrder, string SortBy, string Page, string afterCreateCageory)
        {
            PrepareData(SortOrder, SortBy, Page, afterCreateCageory);
            return View(categories);
        }

        /// <summary>
        /// When the (admin) user wants to delete a category, this method will do that.
        /// In the view, I use ajax call, so after delete, I have to redirect to page in different way.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(string id)
        {
            var categories = objBS.GetAll();
            try
            {
                objBS.Delete(id);
                PrepareData(null, null, null, "A törlés sikeres");

                return Json(new { ok = true, newurl = Url.Action("Index") });
            }
            catch
            {
                PrepareData(null, null, null, "A törlés sikertelen");
                return Json(new { ok = true, newurl = Url.Action("Index") });
            }
        }

        public ActionResult Edit(string id)
        {
            ViewBag.Category = objBS.GetByID(id);
            return View("Edit");
        }

        /// <summary>
        /// This method provides the cagetory editing. I take the original object from the DB, and change the propertys based on the given paramters.
        /// After that I update the DB with the new object, and I redirecting to the Index action.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="originalName"></param>
        /// <returns></returns>
        public ActionResult EditCategory(CATEGORIES category, string originalName)
        {
            try
            {
                CATEGORIES originalCategory = objBS.GetByID(originalName);
                originalCategory.Price = category.Price;
                originalCategory.ProcessLengthInMunites = category.ProcessLengthInMunites;

                objBS.Update(originalCategory);

                return RedirectToAction("Index", new { afterCreateCageory = "A kiválaszott kategória sikeresen szerkesztve!" });
            }
            catch
            {
                TempData["Msg"] = "A kategória szerkesztése sikertelen";
                return RedirectToAction("Edit", new
                {
                    id = originalName
                });
            }
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        /// <summary>
        /// If the model is valid, the user can create a new category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
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