using System.Threading.Tasks;
using Models;

namespace Frontend.Services
{
    public interface IOrdersService
    {
        Task<Order[]> GetOrdersAsync();
        Task<Order> GetOrderAsync(int orderId);
        Task<Product[]> GetOrderProductsAsync(int orderId);
        Task<Product> GetOrderProductAsync(int orderId, int productId);
    }
}
