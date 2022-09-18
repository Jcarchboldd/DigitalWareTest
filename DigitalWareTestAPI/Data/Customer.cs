using System.ComponentModel.DataAnnotations;

namespace DigitalWareTestAPI.Data
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string FullName { get; set; } = null!;
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
