using System.ComponentModel.DataAnnotations;

namespace Labb4_MVCRazor_WebbapplicationsWithC_ASP.NET.Models
{
    public class BookLoanViewModel
    {
        public int BookId { get; set; }

        [Display(Name = "Customer id")]
        public int CustomerId { get; set; }
    }
}
