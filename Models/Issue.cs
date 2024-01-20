using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveBug.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int? CategoryID { get; set; }
        public Category? Category { get; set; }

        [Required]
        public int? PriorityID { get; set; }
        public Priority? Priority { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }
}
