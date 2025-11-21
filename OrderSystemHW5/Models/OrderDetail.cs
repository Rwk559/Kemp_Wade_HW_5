using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderSystemHW5.Models
{
    /// <summary>
    /// Represents a line item on an order.  This linking class forms a many-to-many
    /// relationship between orders and products while also storing payload data
    /// including quantity and pricing information.
    /// </summary>
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        /// <summary>
        /// Quantity of product ordered (required).
        /// </summary>
        [Required]
        public int Quantity { get; set; }

        /// <summary>
        /// Price of the product at the time the order was placed.  Stored explicitly
        /// so that changes in product price do not affect existing orders.
        /// </summary>
        [Display(Name = "Product Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Calculated extended price (quantity * price).  Should be set in controller.
        /// </summary>
        [Display(Name = "Extended Price")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal ExtendedPrice { get; set; }

        /// <summary>
        /// Foreign key to the associated product.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Navigation property to the product.
        /// </summary>
        public Product? Product { get; set; }

        /// <summary>
        /// Foreign key to the associated order.
        /// </summary>
        public int OrderID { get; set; }

        /// <summary>
        /// Navigation property to the order.
        /// </summary>
        public Order? Order { get; set; }
    }
}
