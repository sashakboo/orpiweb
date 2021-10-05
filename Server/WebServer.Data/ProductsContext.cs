using Microsoft.EntityFrameworkCore;
using WebServer.Data.Config;
using WebServer.Data.Entities;

namespace WebServer.Data
{
  public class ProductsContext : DbContext
  {
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }

    public ProductsContext(DbContextOptions<ProductsContext> options)
      :base(options)
    {
      
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new ProductConfig());
      modelBuilder.ApplyConfiguration(new ProductTypeConfig());
    }
  }
}
