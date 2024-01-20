using System.ComponentModel.DataAnnotations;

namespace ActiveBug.Models
{
    public class Priority
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Issue>? Issues { get; set; }
    }
}
