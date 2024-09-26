using System.ComponentModel.DataAnnotations;

namespace Labb4_MVCRazor_WebbapplicationsWithC_ASP.NET.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }

        [Display(Name = "Title")]
        public string BookTitle { get; set; }

        [Display(Name = "Serial number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Author")]
        public string AuthorName { get; set; }

        [Display(Name = "Publisher")]
        public string Publisher { get; set; }

        public bool? IsAvailable { get; set; }

        public int bbh { get; set; }

        public int? CustomerId { get; set; }

        [Display(Name = "Author")]
        public string? FullName { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}
