using System.ComponentModel.DataAnnotations;

namespace TranTuanThinh_2031200036_Lab.Models
{
    public class Carousel
    {
        [Key]
        public required int Id { get; set; }

        [Required]
        public required string ImageUrl { get; set; } = "/avatar.jpg";

        [Required]
        [StringLength(200)]
        public required string Title { get; set; }

        public string? Description { get; set; }

        public string? LinkUrl { get; set; }

        [Required]
        public required int Order { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }
}
