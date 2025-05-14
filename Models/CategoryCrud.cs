namespace NimapInfotechTask.Models
{
    public class CategoryCrud
    {
        private readonly ApplicationDBContext db;

        public CategoryCrud(ApplicationDBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            var result = (from c in db.Categories
                          select c).ToList();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            var result = (from c in db.Categories
                          where c.Category_id == id
                          select c).FirstOrDefault();
            return result;
        }

        public int AddCategory(Category c)
        {
            int result = 0;
            db.Categories.Add(c);
            result = db.SaveChanges();
            return result;
        }

        public int UpdateCategory(Category category)
        {
            int result = 0;

            var query = (from c in db.Categories
                         where c.Category_id == category.Category_id
                         select c).FirstOrDefault();

            if (query != null)
            {
                query.Category_Name = category.Category_Name;
                result = db.SaveChanges();
            }

            return result;
        }

        public int DeleteCategory(int id)
        {
            /* i am adding trigger here name is  trg_DeleteProductsOnCategoryDelete
             * when a category is deleted, all products associated with that 
             * category should also be deleted automatically*/
            int result = 0;

            var query = (from c in db.Categories
                         where c.Category_id == id
                         select c).FirstOrDefault();

            if (query != null)
            {
                db.Categories.Remove(query);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
