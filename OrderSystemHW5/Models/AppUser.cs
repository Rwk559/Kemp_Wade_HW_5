using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace OrderSystemHW5.Models
{
    /// <summary>
    /// Application user extends IdentityUser to add additional profile data.
    /// </summary>
    public class AppUser : IdentityUser
    {
        /// <summary>
        /// The user's first name (required).
        /// </summary>
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// The user's last name (required).
        /// </summary>
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;
    }
}
