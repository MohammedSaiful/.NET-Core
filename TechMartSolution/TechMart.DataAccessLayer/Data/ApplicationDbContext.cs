using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechMart.Domain.Entities;

namespace TechMart.DataAccessLayer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Quantum Laptop", Price = 1200, StockQuantity = 10, Description = "High-end gaming laptop", ImageUrl = "https://placehold.co/200" },
                new Product { Id = 2, Name = "Ergo Mouse", Price = 45, StockQuantity = 50, Description = "Wireless ergonomic mouse", ImageUrl = "https://placehold.co/200" },
                new Product { Id = 3, Name = "Mech Keyboard", Price = 110, StockQuantity = 20, Description = "RGB Mechanical Keyboard", ImageUrl = "https://placehold.co/200" },
                new Product { Id = 4, Name = "4K Monitor", Price = 350, StockQuantity = 15, Description = "Ultra HD Display", ImageUrl = "https://placehold.co/200" },
                new Product { Id = 5, Name = "USB-C Hub", Price = 60, StockQuantity = 100, Description = "7-in-1 Connectivity", ImageUrl = "https://placehold.co/200" }
            );
        }
    }
}
