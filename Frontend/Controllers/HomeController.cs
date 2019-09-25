using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Frontend.Models;
using Frontend.Services;

namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrdersService _service;

        public HomeController(IOrdersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var orders = await _service.GetOrdersAsync();

            var model = new OrdersViewModel()
            {
                Orders = orders
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ViewOrder(int id)
        {
            var orders = await _service.GetOrdersAsync();
            var order = await _service.GetOrderAsync(id);
            var products = await _service.GetOrderProductsAsync(id);

            var model = new OrderViewModel()
            {
                Orders = orders,
                Order = order,
                Products = products
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
