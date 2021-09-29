using Microsoft.EntityFrameworkCore.Design;

namespace WebServer.Data
{
  public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ProductsContext>
  {
    #region IDesignTimeDbContextFactory
    public ProductsContext CreateDbContext(string[] args)
    {
      return new ProductsContext();
    }
    #endregion
  }
}
