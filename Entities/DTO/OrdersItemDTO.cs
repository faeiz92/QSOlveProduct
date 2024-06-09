using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class OrdersItemDTO
    {
        public Guid OrderItemId { get; set; }
        public Guid OrderId { get; set; }
        [Required(ErrorMessage = "ProductId is required")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "OrderQuantity is required")]
        public int OrderQuantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
    }
}
