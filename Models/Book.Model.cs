using System.ComponentModel.DataAnnotations;

namespace TranTuanThinh_2031200036_Lab.Models
{
    public class Book
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }
        public string? Description { get; set; }

        [Required]
        public required string BookCode { get; set; }
        public string? Publisher { get; set; }
        public int PublishedYear { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        public int AuthorId { get; set; }
        public Author? Author { get; set; }

        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }
        public string? PDF { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Avatar { get; set; }

        public ICollection<Loan>? Loans { get; set; }
    }
}
