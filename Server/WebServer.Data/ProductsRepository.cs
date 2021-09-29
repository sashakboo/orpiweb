using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data.Entities;

namespace WebServer.Data
{
  public class ProductsRepository : IProductsRepository
  {
    private readonly ProductsContext context;

    public ProductsRepository(ProductsContext context)
    {
      this.context = context;
    }

    public async Task<IEnumerable<ProductType>> GetCategories()
    {
      return await this.context.ProductTypes
        .ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProducts(int productTypeId)
    {
      return await this.context.Products
        .Include(x => x.Category)
        .Where(x => x.Category.Id == productTypeId)
        .ToListAsync(); ;
    }

    public async Task<IEnumerable<Product>> GetBasket()
    {
      return await this.context.Products
        .Include(x => x.Category)
        .Where(x => x.InBasket)
        .ToListAsync();
    }

    public async Task AddToBasket(Product product)
    {
      var prod = await this.context.Products.FindAsync(product.Id);
      prod.InBasket = true;

      await this.context.SaveChangesAsync();
    }

    public async Task DeleteFromBasket(Product product)
    {
      var prod = await this.context.Products.FindAsync(product.Id);
      prod.InBasket = false;

      await this.context.SaveChangesAsync();
    }
  }
}
