namespace NimapInfotechTask.Models
{
    public class Pagination
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
    }
}
