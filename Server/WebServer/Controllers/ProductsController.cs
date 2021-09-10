using System.Collections.Generic;
using System.Web.Http;
using WebServer.Models;

namespace WebServer.Controllers
{
  public class ProductsController : ApiController
  {
    private readonly ProductsService productService = ProductsService.GetInstance();

    [HttpGet]
    public IEnumerable<ProductType> Categories()
    {
      return productService.GetCategories();
    }

    [HttpGet]
    public IEnumerable<Product> GetProducts(int productTypeId)
    {
      var productType = productService.GetProductType(productTypeId);
      return productService.GetProducts(productType);
    }

    [HttpGet]
    public IEnumerable<Product> GetBasket()
    {
      return productService.GetBasket();
    }

    [HttpPost]
    public IHttpActionResult AddToBasket(Product product)
    {
      productService.AddToBasket(product);

      return Ok();
    }

    [HttpPost]
    public IHttpActionResult DeleteFromBasket(Product product)
    {
      productService.DeleteFromBasket(product);

      return Ok();
    }


  }
}
