using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab08.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public int Year { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        
        public string? Engine { get; set; }
        
        public string? FuelType { get; set; }
        
        public string? Transmission { get; set; }
        
        public string? ImageUrl { get; set; }
        
        // Foreign key
        public int BrandId { get; set; }
        
        // Navigation properties
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; } = null!;
        
        public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
