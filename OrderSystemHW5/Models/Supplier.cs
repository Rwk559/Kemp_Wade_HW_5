using System.ComponentModel.DataAnnotations;

namespace OrderSystemHW5.Models


    /// <summary>
    /// Represents a supplier (vendor) that provides products to the store.  This class
    /// contains basic contact information and a navigational property to the products
    /// supplied.  Note that a supplier is a company rather than a person.
    /// </summary>
    public class Supplier
    {
        public int SupplierID { get; set; }

        /// <summary>
        /// Name of the supplier company (required).
        /// </summary>
        [Required]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; } = string.Empty;

        /// <summary>
        /// Contact email for the supplier (optional).
        /// </summary>
        [EmailAddress]
        public string? Email { get; set; }

        /// <summary>
        /// Contact phone number for the supplier (optional).
        /// </summary>
        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Many-to-many relationship to the products provided by this supplier.  No
        /// payload data is required for this relationship.
        /// </summary>
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
