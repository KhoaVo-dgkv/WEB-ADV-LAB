using System.ComponentModel.DataAnnotations;

namespace Lab09API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        // Navigation property
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
