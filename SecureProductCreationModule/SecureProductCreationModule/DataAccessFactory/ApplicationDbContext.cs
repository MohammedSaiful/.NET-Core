using Microsoft.EntityFrameworkCore;
using SecureProductCreationModule.Entities;

namespace SecureProductCreationModule.DataAccessFactory
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToTable("Product");

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Books",
                        Price = 100,
                        Description = "Reading materials",
                        CreatedDate = new DateTime(2024, 1, 1)
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "NoteBook",
                        Price = 200,
                        Description = "Writing material",
                        CreatedDate = new DateTime(2024, 1, 1)
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Pen",
                        Price = 10,
                        Description = "Writing material",
                        CreatedDate = new DateTime(2024, 1, 1)
                    }
                );
        }
    }

}
