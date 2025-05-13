using System.ComponentModel.DataAnnotations;

namespace TranTuanThinh_2031200036_Lab.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public required string Fullname { get; set; }
        public string? Description { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public required string Email { get; set; }

        [StringLength(20)]
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? UserCode { get; set; }

        public bool IsLocked { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public string? ActiveCode { get; set; }
        public string? Avatar { get; set; }

        public ICollection<Loan>? Loans { get; set; }
    }
}
