using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb4_MVCRazor_WebbapplicationsWithC_ASP.NET.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        [Display(Name = "Title")]
        public string BookTitle { get; set; }

        [Required]
        [StringLength(maximumLength: 30)]
        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        [Display(Name = "Author first name")]
        public string AuthorFirstName { get; set; }

        [Required]
        [StringLength(maximumLength: 70, MinimumLength = 1)]
        [Display(Name = "Author last name")]
        public string AuthorLastName { get; set; }

        [NotMapped]
        [DisplayName("Author")]
        public string FullName => $"{AuthorFirstName} {AuthorLastName}";

        [StringLength(maximumLength: 70, MinimumLength = 1)]
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }

        public bool? IsCheckedOut { get; set; } = false;

        public ICollection<BookLoanHistory> BookLoansHistories { get; set; }
    }
}
