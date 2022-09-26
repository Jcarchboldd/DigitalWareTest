namespace DigitalWare.Domain.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public DateTime OrderDate { get; set; }

        public Customer Customer { get; set; } = null!;

        public ICollection<Order_Detail> Order_Details { get; set; } = null!;


    }
}
