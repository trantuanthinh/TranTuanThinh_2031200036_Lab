using System.ComponentModel.DataAnnotations;

namespace TranTuanThinh_2031200036_Lab.Models
{
    public class Author
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Biography { get; set; }

        [StringLength(100)]
        public string? Nationality { get; set; }

        [Required]
        [StringLength(100)]
        public required string Email { get; set; }

        [StringLength(100)]
        public string? Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string? Avatar { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
