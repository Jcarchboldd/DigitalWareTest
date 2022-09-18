using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWareTestAPI.Data
{
    public class Order_Detail
    {
        [Key]
        [Column(Order = 0)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }
    }

}
