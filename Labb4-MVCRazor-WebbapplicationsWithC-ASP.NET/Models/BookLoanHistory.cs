using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb4_MVCRazor_WebbapplicationsWithC_ASP.NET.Models
{
    public class BookLoanHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookLoanHistoryId { get; set; }

        [Required]
        [Display(Name = "Title")]
        public int BookId { get; set; }

        public Book? Books { get; set; }

        [Required]
        [Display(Name = "Customer id")]
        public int CustomerId { get; set; }

        public Customer? Customers { get; set; }

        [Display(Name = "Checked out")]
        public DateTime CheckoutDate { get; set; }

        [Display(Name = "Returned")]
        public DateTime? ReturnDate { get; set; }
    }
}
