namespace DigitalWare.Cross_cutting.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = null!;
        public decimal Amount { get; set; }
    }
}
