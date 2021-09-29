using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Models;
using WebServer.Services;

namespace WebServer.Controllers
{
  [Route("[controller]/[action]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly IProductsService productService;

    public ProductsController(IProductsService productsService)
    {
      this.productService = productsService;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductTypeDto>> Categories()
    {
      return await this.productService.GetCategories();
    }

    [HttpGet]
    public async Task<IEnumerable<ProductDto>> GetProducts(int productTypeId)
    {
      return await this.productService.GetProducts(productTypeId);
    }

    [HttpGet]
    public async Task<IEnumerable<ProductDto>> GetBasket()
    {
      return await this.productService.GetBasket();
    }

    [HttpPost]
    public async Task<IActionResult> AddToBasket(ProductDto product)
    {
      await this.productService.AddToBasket(product);

      return this.Ok();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteFromBasket(ProductDto product)
    {
      await this.productService.DeleteFromBasket(product);

      return this.Ok();
    }
  }
}
