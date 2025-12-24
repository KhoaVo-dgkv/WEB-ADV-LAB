using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab08.Models
{
    public class Car
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string LicensePlate { get; set; } = string.Empty;
        
        [StringLength(17)]
        public string? VIN { get; set; }
        
        public string? Color { get; set; }
        
        public int Mileage { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentPrice { get; set; }
        
        public string? Condition { get; set; }
        
        public DateTime PurchaseDate { get; set; }
        
        public string? Notes { get; set; }
        
        public bool IsAvailable { get; set; } = true;
        
        // Foreign key
        public int CarModelId { get; set; }
        
        // Navigation property
        [ForeignKey("CarModelId")]
        public virtual CarModel CarModel { get; set; } = null!;
    }
}
