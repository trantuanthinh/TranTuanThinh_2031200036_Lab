using System.ComponentModel.DataAnnotations;

namespace TranTuanThinh_2031200036_Lab.Models

{
    public class Loan
    {
        [Required]
        public int LoanId { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required]
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string? Status { get; set; }
    }
}
