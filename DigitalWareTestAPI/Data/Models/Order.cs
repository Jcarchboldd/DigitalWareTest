using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalWareTestAPI.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; } = null!;

        public ICollection<Order_Detail> Order_Details { get; set; } = null!;


    }
}
