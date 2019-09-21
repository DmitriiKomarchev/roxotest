using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly OrdersContext _context;

        public OrdersService(OrdersContext context)
        {
            _context = context;
        }

        public async Task<Order[]> GetOrdersAsync()
        {
            return await _context.Orders.ToArrayAsync();
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            return await _context.Orders.FindAsync(orderId);
        }

        public async Task<Product[]> GetOrderProductsAsync(int orderId)
        {
            return await _context.Products.Where(p => p.OrderId == orderId).ToArrayAsync();
        }

        public async Task<Product> GetOrderProductAsync(int orderId, int productId)
        {
            return await _context.Products.Where(p => p.OrderId == orderId && p.ProductId == productId).FirstOrDefaultAsync();
        }
    }
}
