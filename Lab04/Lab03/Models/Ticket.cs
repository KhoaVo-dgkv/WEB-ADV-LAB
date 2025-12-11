using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab03.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Movie")]
        public int MovieId { get; set; }
        
        [Required]
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        
        [Required]
        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        
        [Required]
        [Range(0.01, 10000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        
        [StringLength(20)]
        [Display(Name = "Seat Number")]
        public string? SeatNumber { get; set; }
        
        // Navigation properties
        [Display(Name = "Movie")]
        public Movie Movie { get; set; } = null!;
        
        [Display(Name = "Customer")]
        public Customer Customer { get; set; } = null!;
    }
}

