using Backend.Controllers;
using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using FluentAssertions;
using Models;
using Xunit;

namespace BackendTests
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task Get_NoOrders_ReturnsNotFound()
        {
            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrdersAsync()).ReturnsAsync(new Order[0]);

            var controller = new ProductsController(service.Object);

            var actual = await controller.Get(0);

            actual.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Get_OrderInvalidId_ReturnsNotFound()
        {
            const int orderId = 1;

            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrderProductsAsync(It.Is<int>(i => i != orderId))).ReturnsAsync(new Product[0]);

            var controller = new ProductsController(service.Object);

            var actual = await controller.Get(0);

            actual.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Get_OrderValidId_ReturnsProducts()
        {
            const int orderId = 1;
            const int productId = 1;
            var productStub = new Product()
            {
                ProductId = productId,
                OrderId = orderId,
                ProductName = "Product #1"
            };

            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrderProductsAsync(It.Is<int>(i => i == orderId))).ReturnsAsync(new[] { productStub });

            var controller = new ProductsController(service.Object);

            var actual = await controller.Get(orderId);

            actual.Value.Should().NotBeNullOrEmpty();
            actual.Value.Should().Contain(productStub);
        }

        [Fact]
        public async Task Get_OrderValidIdProductValidId_ReturnsProduct()
        {
            const int orderId = 1;
            const int productId = 1;
            var productStub = new Product()
            {
                ProductId = productId,
                OrderId = orderId,
                ProductName = "Product #1"
            };

            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrderProductAsync(It.Is<int>(i => i == orderId), It.Is<int>(i => i == productId)))
                .ReturnsAsync(productStub);

            var controller = new ProductsController(service.Object);

            var actual = await controller.Get(orderId, productId);

            actual.Value.Should().Be(productStub);
        }

        [Fact]
        public async Task Get_OrderValidIdProductInvalidId_ReturnsNotFound()
        {
            const int orderId = 1;
            const int productId = 1;
            var productStub = new Product()
            {
                ProductId = productId,
                OrderId = orderId,
                ProductName = "Product #1"
            };

            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrderProductAsync(It.Is<int>(i => i == orderId), It.Is<int>(i => i == productId)))
                .ReturnsAsync(productStub);

            var controller = new ProductsController(service.Object);

            var actual = await controller.Get(orderId, 0);

            actual.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Get_OrderInvalidIdProductValidId_ReturnsNotFound()
        {
            const int orderId = 1;
            const int productId = 1;
            var productStub = new Product()
            {
                ProductId = productId,
                OrderId = orderId,
                ProductName = "Product #1"
            };

            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrderProductAsync(It.Is<int>(i => i == orderId), It.Is<int>(i => i == productId)))
                .ReturnsAsync(productStub);

            var controller = new ProductsController(service.Object);

            var actual = await controller.Get(0, productId);

            actual.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}
