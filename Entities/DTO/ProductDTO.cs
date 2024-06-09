using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ProductDTO
    {
        //public Guid ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is required")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "ProductCategoryID is required")]
        public Guid ProductCategoryId { get; set; }
    }
}
