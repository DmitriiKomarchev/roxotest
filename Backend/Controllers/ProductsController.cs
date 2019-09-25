using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/orders/{orderId}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IOrdersService _service;

        public ProductsController(IOrdersService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Product>>> Get(int orderId)
        {
            var products = await _service.GetOrderProductsAsync(orderId);

            if (!products.Any())
            {
                return NotFound();
            }

            return products;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Product>> Get(int orderId, int id)
        {
            var product = await _service.GetOrderProductAsync(orderId, id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
    }
}
