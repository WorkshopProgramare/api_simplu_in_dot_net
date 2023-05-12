using Microsoft.EntityFrameworkCore;
using ProductsAPI.Entities;

namespace ProductsAPI.Database
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                Currency = "EUR",
                Depth = 9,
                Height = 10,
                Width = 0,
                Manufacturer = "Victor",
                ProductName = "Master Product",
                ProductWeight = 1,
                Value = 25,
            });
        }
        public DbSet<Product> Products { get; set; }
    }
}
