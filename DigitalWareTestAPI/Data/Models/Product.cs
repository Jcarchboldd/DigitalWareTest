using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWareTestAPI.Data.Models
{
    [Table("Products")]
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
