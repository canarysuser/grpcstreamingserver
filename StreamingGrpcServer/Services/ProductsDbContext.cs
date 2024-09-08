using Microsoft.EntityFrameworkCore;
using ProductServices.Streaming.Demo;

namespace StreamingGrpcServer.Services
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Product>().Ignore(p => p.UpdateTime);
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
