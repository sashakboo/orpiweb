using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace WebServer.Data
{
  public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ProductsContext>
  {
    #region IDesignTimeDbContextFactory
    public ProductsContext CreateDbContext(string[] args)
    {
      var folder = AppDomain.CurrentDomain.BaseDirectory;
      var path = System.IO.Path.Combine(folder, "storage");
      System.IO.Directory.CreateDirectory(path);
      var dbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}products.db";

      var optionsBuilder = new DbContextOptionsBuilder<ProductsContext>();
      optionsBuilder.UseSqlite($"Data Source={dbPath}");
      return new ProductsContext(optionsBuilder.Options);
    }
    #endregion
  }
}
