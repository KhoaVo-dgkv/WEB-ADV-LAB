using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Lab09API.DTOs
{
    public class UpdateProductDto
    {
        [Required]
        public string Name { get; set; } = null!;
        
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        
        [Required]
        public int CategoryId { get; set; }
        
        public IFormFile? Image { get; set; }
    }
}

