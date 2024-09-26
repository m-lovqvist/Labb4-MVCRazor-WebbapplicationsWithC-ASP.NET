using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb4_MVCRazor_WebbapplicationsWithC_ASP.NET.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Customer")]
        public string FullName => $"{FirstName} {LastName}";

        [Required]
        [StringLength(maximumLength: 50)]
        [Display(Name = "Street name")]
        public string StreetName { get; set; }

        [Display(Name = "House number")]
        public int HouseNumber { get; set; }

        [StringLength(maximumLength: 40, MinimumLength = 1)]
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Phone number")]
        public string? PhoneNumber { get; set; }
    }
}
