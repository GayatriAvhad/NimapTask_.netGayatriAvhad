using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NimapInfotechTask.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Product Id")]
        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "product name is required.")]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "product price is required.")]
        public int Price { get; set; }

        public int CategoryId { get; set; }


        [NotMapped]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}
