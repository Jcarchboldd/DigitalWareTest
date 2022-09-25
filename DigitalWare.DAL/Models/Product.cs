namespace DigitalWare.Domain.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string ProductName { get; set; } = null!;

        public int UnitsInStock { get; set; }

        public decimal UnitPrice { get; set; }

        public bool Status { get; set; }

    }
}
