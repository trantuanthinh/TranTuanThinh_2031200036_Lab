using System.ComponentModel.DataAnnotations;

namespace TranTuanThinh_2031200036_Lab.Models

{
    public class Category
    {
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string? Avatar { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
