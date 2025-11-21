using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace OrderSystemHW5.Models
{
    /// <summary>
    /// Represents a customer's order.  Contains scalar properties for order metadata
    /// and navigational properties to the customer and order details.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// The sales tax rate used to calculate tax on orders.  Declared as a constant
        /// so that it is easy to adjust in the future if rates change.
        /// </summary>
        public const decimal TAX_RATE = 0.0825m;

        public int OrderID { get; set; }

        /// <summary>
        /// Sequential order number beginning at 70001.  The controller logic should
        /// generate the next order number; users should not edit this value.
        /// </summary>
        [Display(Name = "Order Number")]
        public int OrderNumber { get; set; }

        /// <summary>
        /// Date and time when the order was placed.  The controller logic should set
        /// this automatically using DateTime.Now.
        /// </summary>
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Optional order notes entered by the customer.
        /// </summary>
        public string? OrderNotes { get; set; }

        /// <summary>
        /// Foreign key to the AppUser who placed the order.
        /// </summary>
        public string AppUserId { get; set; } = string.Empty;

        /// <summary>
        /// Navigation property to the user who placed the order.
        /// </summary>
        public AppUser? AppUser { get; set; }

        /// <summary>
        /// Collection of order details for this order.
        /// </summary>
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        /// <summary>
        /// Read-only property that sums the extended prices of the order details to
        /// produce a subtotal.
        /// </summary>
        [NotMapped]
        [Display(Name = "Subtotal")]
        public decimal Subtotal => OrderDetails.Sum(od => od.ExtendedPrice);

        /// <summary>
        /// Read-only property that calculates sales tax based on the subtotal.
        /// </summary>
        [NotMapped]
        [Display(Name = "Sales Tax")]
        public decimal SalesTax => Subtotal * TAX_RATE;

        /// <summary>
        /// Read-only property that calculates the total by adding subtotal and tax.
        /// </summary>
        [NotMapped]
        [Display(Name = "Total")]
        public decimal Total => Subtotal + SalesTax;
    }
}
