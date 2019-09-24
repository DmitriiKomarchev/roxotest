namespace Backend.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}