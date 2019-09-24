using System;
using System.Collections.Generic;

namespace Backend.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Total { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}