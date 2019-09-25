using System.Net.Http;
using System.Threading.Tasks;
using Models;
using Newtonsoft.Json;

namespace Frontend.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly string _endpoint;

        public OrdersService(string endpoint)
        {
            _endpoint = endpoint;
        }

        public async Task<Order[]> GetOrdersAsync()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{_endpoint}api/orders"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var orders = JsonConvert.DeserializeObject<Order[]>(apiResponse);
                    return orders;
                }
            }
        }

        public async Task<Order> GetOrderAsync(int orderId)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{_endpoint}api/orders/{orderId}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var order = JsonConvert.DeserializeObject<Order>(apiResponse);
                    return order;
                }
            }
        }

        public async Task<Product[]> GetOrderProductsAsync(int orderId)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{_endpoint}api/orders/{orderId}/products"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var products = JsonConvert.DeserializeObject<Product[]>(apiResponse);
                    return products;
                }
            }
        }

        public async Task<Product> GetOrderProductAsync(int orderId, int productId)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync($"{_endpoint}api/orders/{orderId}/products/{productId}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var product = JsonConvert.DeserializeObject<Product>(apiResponse);
                    return product;
                }
            }
        }
    }
}
