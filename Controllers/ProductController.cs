using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NimapInfotechTask.Models;

namespace NimapInfotechTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDBContext db_context;

        private ProductCrud crud;
        public ProductController(ApplicationDBContext db_context)
        {
            this.db_context = db_context;

            crud = new ProductCrud(this.db_context);
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(crud.GetAllProducts(1));
        }
        [HttpPost]
        public ActionResult Index(int currentpageindex)
        {
            return View(crud.GetAllProducts(currentpageindex));
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(crud.GetProductById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            ViewBag.Categories = db_context.Categories.ToList();
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            try
            {
                ViewBag.Categories = db_context.Categories.ToList();
                int res = crud.AddProduct(product);

                if (res > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["message"] = "Not able to add record.";
                }
                return View();

            }
            catch (Exception ex)
            {
                TempData["exp"] = "Exception: " + ex.Message;
                ViewBag.Categories = db_context.Categories?.ToList() ?? new List<Category>();
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = crud.GetProductById(id);
            ViewBag.Categories = db_context.Categories.ToList();
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            try
            {
                ViewBag.Categories = db_context.Categories.ToList();
                int result = crud.UpdateProduct(product);
                if (result > 0)
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
                TempData["exp"] = "Exception: " + ex.Message;
                ViewBag.Categories = db_context.Categories?.ToList() ?? new List<Category>();
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(crud.GetProductById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = crud.DeleteProduct(id);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    TempData["message"] = "Not able to delete record.";
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
