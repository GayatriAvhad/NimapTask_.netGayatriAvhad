using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NimapInfotechTask.Models;

namespace NimapInfotechTask.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDBContext db_context;

        private CategoryCrud crud;

        public CategoryController(ApplicationDBContext db_context)
        {
            this.db_context = db_context;

            crud = new CategoryCrud(this.db_context);
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(crud.GetAllCategories());
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {

            return View(crud.GetCategoryById(id));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                int result = crud.AddCategory(category);

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["message"] = "Category Record Is Not Added...";
                }
                return View(category);

            }
            catch (Exception ex)
            {
                TempData["exp"] = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(crud.GetCategoryById(id));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                int result = crud.UpdateCategory(category);

                if (result != 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["message"] = "Not able to update record.";
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["exp"] = ex.Message;
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(crud.GetCategoryById(id));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteCategory(id);

                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["message"] = "Not able to Delete record.";
                }
                return View();
            }
            catch (Exception ex)
            {
                TempData["exp"] = ex.Message;
                return View();
            }
        }
    }
}
