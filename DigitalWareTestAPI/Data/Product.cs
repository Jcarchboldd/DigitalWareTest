using System.ComponentModel.DataAnnotations;

namespace DigitalWareTestAPI.Data
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        [Required]
        public int UnitsInStock { get; set; }

        [Required]
        public int UnitPrice { get; set; }

        [Required]
        public bool Status { get; set; }
    }
}
