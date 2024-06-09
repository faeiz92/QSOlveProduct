using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("ORDERS")]
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ORDER_ID")]
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "CustomerId is required")]
        [Column("CUSTOMER_ID", TypeName = "int")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "OrderDateTime is required")]
        [Column("ORDER_DATETIME", TypeName = "date")]
        public DateTime OrderDateTime { get; set; }

        [Required(ErrorMessage = "TotalPrice is required")]
        [Column("TOTAL_PRICE", TypeName = "decimal")]
        public decimal TotalPrice { get; set; }

        //public Guid OrderItemId { get; set; }
        //[ForeignKey("OrderItemId")]
        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
