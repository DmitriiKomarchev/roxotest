using Models;

namespace Frontend.Models
{
    public class OrderViewModel
    {
        public Order[] Orders { get; set; }
        public Order Order { get; set; }
        public Product[] Products { get; set; }
    }
}
