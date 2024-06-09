using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    [Table("PRODUCT")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("PRODUCT_ID")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        [Column("PRODUCT_NAME", TypeName = "string")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Column("DESCRIPTION", TypeName = "string")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ProductCategoryID is required")]
        public Guid ProductCategoryId { get; set; }
        public virtual ProductCategory ProductCategories { get; set; } = null!;
        //public virtual OrderItem OrderItems { get; set; } = null!;


    }
}
