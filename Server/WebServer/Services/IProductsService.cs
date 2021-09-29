using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Models;

namespace WebServer.Services
{
  public interface IProductsService
  {
    public Task<IEnumerable<ProductTypeDto>> GetCategories();

    public Task<IEnumerable<ProductDto>> GetProducts(int productTypeId);

    public Task<IEnumerable<ProductDto>> GetBasket();

    public Task AddToBasket(ProductDto product);

    public Task DeleteFromBasket(ProductDto product);
  }
}
