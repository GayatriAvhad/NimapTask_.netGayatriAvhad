using Microsoft.EntityFrameworkCore;

namespace NimapInfotechTask.Models
{
    public class ProductCrud
    {
        private readonly ApplicationDBContext db;
        public ProductCrud(ApplicationDBContext db)
        {
            this.db = db;
        }

        public Pagination GetAllProducts(int currentPage, int pageSize = 10)
        {
            var totalProducts = db.Products.Count();

            var products = db.Products
                .Include(p => p.Category)
                .OrderBy(p => p.ProductId)
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            foreach (var p in products)
            {
                p.CategoryName = db.Categories
                    .Where(c => c.Category_id == p.CategoryId)
                    .Select(c => c.Category_Name)
                    .FirstOrDefault();
            }

            var pageCount = (int)Math.Ceiling((double)totalProducts / pageSize);

            return new Pagination
            {
                ProductList = products ?? new List<Product>(),
                CurrentPageIndex = currentPage,
                PageCount = pageCount > 0 ? pageCount : 1
            };
        }


        public Product GetProductById(int id)
        {
            var result = (from p in db.Products
                          where p.ProductId == id
                          select p).FirstOrDefault();
            return result;
        }

        public int AddProduct(Product p)
        {
            int result = 0;
            db.Products.Add(p);
            result = db.SaveChanges();
            return result;

        }

        public int UpdateProduct(Product pro)
        {
            int result = 0;

            var product = (from p in db.Products
                           where p.ProductId == pro.ProductId
                           select p).FirstOrDefault();

            if (product != null)
            {
                product.ProductName = pro.ProductName;
                product.Price = pro.Price;
                product.CategoryId = pro.CategoryId;
                product.CategoryName = pro.CategoryName;

                result = db.SaveChanges();
            }
            return result;
        }

        public int DeleteProduct(int id)
        {
            int result = 0;
            var product = (from p in db.Products
                           where p.ProductId == id
                           select p).FirstOrDefault();

            if (product != null)
            {
                db.Remove(product);
                result = db.SaveChanges();
            }

            return result;
        }
    }
}
