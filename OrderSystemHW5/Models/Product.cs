using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderSystemHW5.Models
{
    /// <summary>
    /// Enum to capture the available product types.  The store does not intend to add
    /// new types dynamically, so an enum is appropriate here.
    /// </summary>
    public enum ProductType
    {
        NewHardback,
        NewPaperback,
        UsedHardback,
        UsedPaperback,
        Other
    }

    /// <summary>
    /// Represents a product that can be purchased by customers.  This class includes
    /// basic scalar properties along with navigational properties for relationships.
    /// </summary>
    public class Product
    {
        public int ProductID { get; set; }

        /// <summary>
        /// The name of the product (required).
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// A brief description of the product (optional).
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The current price of the product (required).  Two decimal places are specified
        /// for storage in SQL Server.
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// The type of product (required).  See the ProductType enum.
        /// </summary>
        [Required]
        public ProductType ProductType { get; set; }

        /// <summary>
        /// Many-to-many relationship with suppliers (no payload).  EF Core will create
        /// a join table behind the scenes.  A product can have multiple suppliers and
        /// vice versa.
        /// </summary>
        public ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

        /// <summary>
        /// Collection of order details for this product.  A product can appear on many
        /// different orders via the OrderDetail linking class.
        /// </summary>
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
