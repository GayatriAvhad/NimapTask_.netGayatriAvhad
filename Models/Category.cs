using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NimapInfotechTask.Models
{
    [Table("Categories")]
    public class Category
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Category Id")]
        public int Category_id { get; set; }

        [Required(ErrorMessage = "category name is required.")]
        [Display(Name = "Category Name")]
        public string Category_Name { get; set; }
    }
}
