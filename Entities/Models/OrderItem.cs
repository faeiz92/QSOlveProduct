using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("ORDER_ITEM")]
    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ORDER_ITEM_ID")]
        public Guid OrderItemId { get; set; }

        
        public Guid OrderId { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual OrderItem OrderItems { get; set; }

        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }

        //[ForeignKey("ProductId")]
        //public virtual Product Products { get; set; }

        [Required(ErrorMessage = "OrderQuantity is required")]
        [Column("ORDER_QUANTITY", TypeName = "int")]
        public int OrderQuantity { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Column("PRICE", TypeName = "decimal")]
        public decimal Price { get; set; }

        [ForeignKey("OrderId")]
        public Guid OrdersOrderId { get; set; }
        public virtual Orders Orders { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
