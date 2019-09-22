using Backend.Services;
using Moq;
using System.Threading.Tasks;
using Backend.Controllers;
using Backend.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace BackendTests
{
    public class OrdersControllerTests
    {
        [Fact]
        public async Task Get_NoOrders_ReturnsNotFound()
        {
            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrdersAsync()).ReturnsAsync(new Order[0]);

            var controller = new OrdersController(service.Object);

            var actual = await controller.Get();

            actual.Result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Get_OneOrder_ReturnsOneOrder()
        {
            const int orderId = 1;
            var orderStub = new Order()
            {
                OrderId = orderId,
                Number = "Order #1"
            };

            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrdersAsync()).ReturnsAsync(new[] { orderStub });

            var controller = new OrdersController(service.Object);

            var actual = await controller.Get();

            actual.Value.Should().NotBeNullOrEmpty();
            actual.Value.Should().Contain(orderStub);
        }

        [Fact]
        public async Task Get_OrderByValidId_ReturnsOrder()
        {
            const int orderId = 1;
            var orderStub = new Order()
            {
                OrderId = orderId,
                Number = "Order #1"
            };

            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrderAsync(It.Is<int>(i => i == orderId))).ReturnsAsync(orderStub);

            var controller = new OrdersController(service.Object);

            var actual = await controller.Get(orderId);

            actual.Value.Should().Be(orderStub);
        }

        [Fact]
        public async Task Get_OrderByInvalidId_ReturnsNotFound()
        {
            const int orderId = 1;
            var orderStub = new Order()
            {
                OrderId = orderId,
                Number = "Order #1"
            };

            var service = new Mock<IOrdersService>();
            service.Setup(d => d.GetOrderAsync(It.Is<int>(i => i == orderId))).ReturnsAsync(orderStub);
            service.Setup(d => d.GetOrderAsync(It.Is<int>(i => i != orderId))).ReturnsAsync((Order)null);

            var controller = new OrdersController(service.Object);

            var actual = await controller.Get(0);

            actual.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}
