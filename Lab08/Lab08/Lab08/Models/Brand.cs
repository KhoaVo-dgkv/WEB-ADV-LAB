using System.ComponentModel.DataAnnotations;

namespace Lab08.Models
{
    public class Brand
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public string? Country { get; set; }
        
        public DateTime EstablishedYear { get; set; }
        
        // Navigation property
        public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();
    }
}
