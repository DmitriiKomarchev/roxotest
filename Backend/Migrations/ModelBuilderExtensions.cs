using System;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Backend.Migrations
{
    public static class ModelBuilderExtensions
    {
        public static void InitialDataSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order()
                {
                    OrderId = 1,
                    Number = "Order #1",
                    Date = DateTime.Parse("10.20.2017 01:10"),
                    Status = OrderStatus.InProgress,
                    Total = 3333.0m
                },
                new Order()
                {
                    OrderId = 2,
                    Number = "Order #2",
                    Date = DateTime.Parse("01.10.2017 05:30"),
                    Status = OrderStatus.Complete,
                    Total = 5555.0m
                }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ProductId = 1,
                    OrderId = 1,
                    ProductName = "Product #1",
                    Qty = 1.0m,
                    Price = 100.0m,
                    Total = 100.0m
                },
                new Product()
                {
                    ProductId = 2,
                    OrderId = 1,
                    ProductName = "Product #2",
                    Qty = 5.0m,
                    Price = 10.0m,
                    Total = 50.0m
                },
                new Product()
                {
                    ProductId = 3,
                    OrderId = 1,
                    ProductName = "Product #3",
                    Qty = 1.0m,
                    Price = 5.0m,
                    Total = 5.0m
                },
                new Product()
                {
                    ProductId = 4,
                    OrderId = 1,
                    ProductName = "Product #4",
                    Qty = 2.0m,
                    Price = 10.0m,
                    Total = 20.0m
                },
                new Product()
                {
                    ProductId = 5,
                    OrderId = 2,
                    ProductName = "Product #1",
                    Qty = 2.0m,
                    Price = 100.0m,
                    Total = 200.0m
                },
                new Product()
                {
                    ProductId = 6,
                    OrderId = 2,
                    ProductName = "Product #2",
                    Qty = 5.0m,
                    Price = 20.0m,
                    Total = 100.0m
                },
                new Product()
                {
                    ProductId = 7,
                    OrderId = 2,
                    ProductName = "Product #3",
                    Qty = 2.0m,
                    Price = 5.0m,
                    Total = 10.0m
                },
                new Product()
                {
                    ProductId = 8,
                    OrderId = 2,
                    ProductName = "Product #4",
                    Qty = 1.0m,
                    Price = 10.0m,
                    Total = 10.0m
                }
            );
        }
    }
}
