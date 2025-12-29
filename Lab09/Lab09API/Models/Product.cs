using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab09API.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = null!;
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        [Required]
        public string ImageUrl { get; set; } = null!;
        
        [Required]
        public int CategoryId { get; set; }
        
        // Navigation property
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
    }
}
