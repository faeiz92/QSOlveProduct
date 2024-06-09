using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class OrdersDTO
    {
        public Guid OrderId { get; set; }
        [Required(ErrorMessage = "The CustomerId field is required.")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "The OrderDateTime field is required.")]
        public DateTime OrderDateTime { get; set; }
        [Required(ErrorMessage = "The TotalPric field is required.")]
        public decimal TotalPrice { get; set; }
        public OrdersItemDTO Items { get; set; }
    }
}
