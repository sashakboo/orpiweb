using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;
using WebServer.Data.Entities;
using WebServer.Models;

namespace WebServer.Services
{
  public class ProductsService : IProductsService
  {
    private readonly IProductsRepository repository;

    private readonly IMapper mapper;

    public ProductsService(IProductsRepository repository, IMapper mapper)
    {
      this.repository = repository;
      this.mapper = mapper;
    }

    public async Task<IEnumerable<ProductTypeDto>> GetCategories()
    {
      var categories = await this.repository.GetCategories();
      return categories.Select(x => this.mapper.Map<ProductTypeDto>(x));
    }

    public async Task<IEnumerable<ProductDto>> GetProducts(int productTypeId)
    {
      var products = await this.repository.GetProducts(productTypeId);
      return products.Select(x => this.mapper.Map<ProductDto>(x));
    }

    public async Task<IEnumerable<ProductDto>> GetBasket()
    {
      var basket = await this.repository.GetBasket();
      return basket.Select(x => this.mapper.Map<ProductDto>(x));
    }

    public async Task AddToBasket(ProductDto product)
    {
      await this.repository.AddToBasket(this.mapper.Map<Product>(product));
    }

    public async Task DeleteFromBasket(ProductDto product)
    {
      await this.repository.DeleteFromBasket(this.mapper.Map<Product>(product));
    }
  }
}
