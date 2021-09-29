using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebServer.Data.Entities;

namespace WebServer.Data
{
  public class ProductsContextSeed
  {
    public static async Task Seed(ProductsContext context)
    {
      await context.Database.MigrateAsync();

      if (!await context.ProductTypes.AnyAsync())
      {
        await context.ProductTypes.AddRangeAsync(
          new ProductType() { Name = "phones", Title = "Телефоны" },
          new ProductType() { Name = "kitchen", Title = "Техника для кухни" },
          new ProductType() { Name = "toys", Title = "Игрушки" },
          new ProductType() { Name = "tvs", Title = "Телевизоры" },
          new ProductType() { Name = "other", Title = "Другое" }
        );

        await context.SaveChangesAsync();
      }

      if (!await context.Products.AnyAsync())
      {
        var products = new List<Product>();
        var categories = await context.ProductTypes.ToListAsync();

        var rnd = new Random();
        for (var i = 0; i < 100; i++)
        {
          var num = rnd.Next(0, categories.Count);
          var category = categories[num];
          var product = new Product()
          {
            Category = category,
            InBasket = false,
            Name = category.Title + " " + i.ToString(),
            Price = i * num * 100
          };

          products.Add(product);
        }

        await context.Products.AddRangeAsync(products);
        await context.SaveChangesAsync();
      }
    }
  }
}
