using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Data.Entities;

namespace WebServer.Data
{
  public interface IProductsRepository
  {
    public Task<IEnumerable<ProductType>> GetCategories();

    public Task<IEnumerable<Product>> GetProducts(int productTypeId);

    public Task<IEnumerable<Product>> GetBasket();

    public Task AddToBasket(Product product);

    public Task DeleteFromBasket(Product product);
  }
}
