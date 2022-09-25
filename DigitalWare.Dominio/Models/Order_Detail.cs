namespace DigitalWare.Domain.Models
{
    public class Order_Detail
    {

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public Order? Order { get; set; }
    }
}
