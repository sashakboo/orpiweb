using Microsoft.EntityFrameworkCore;
using System;
using WebServer.Data.Config;
using WebServer.Data.Entities;

namespace WebServer.Data
{
  public class ProductsContext : DbContext
  {
    public DbSet<Product> Products { get; set; }

    public DbSet<ProductType> ProductTypes { get; set; }

    public ProductsContext()
    {
      
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      var folder = AppDomain.CurrentDomain.BaseDirectory;
      var path = System.IO.Path.Combine(folder, "storage");
      System.IO.Directory.CreateDirectory(path);
      var dbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}products.db";

      optionsBuilder.UseSqlite($"Data Source={dbPath}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.ApplyConfiguration(new ProductConfig());
      modelBuilder.ApplyConfiguration(new ProductTypeConfig());
    }
  }
}
