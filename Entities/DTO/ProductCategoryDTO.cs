using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ProductCategoryDTO
    {
        public Guid ProductCategoryId { get; set; }

        [Required(ErrorMessage = "ProductCategoryName is required")]
        public string ProductCategoryName { get; set; }
    }
}
