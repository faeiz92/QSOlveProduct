using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    [Table("PRODUCT_CATEGORY")]
    public class ProductCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PRODUCT_CATEGORY_ID")]
        public Guid ProductCategoryId { get; set; }

        [Required(ErrorMessage = "ProductCategoryName is required")]
        [Column("PRODUCT_CATEGORY_NAME", TypeName = "string")]
        public string ProductCategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}
