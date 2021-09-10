using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServer.Models;

namespace WebServer
{
  public class ProductsService
  {
    private static readonly ProductsService instance = new ProductsService();

    private readonly List<ProductType> categories;

    private readonly List<Product> products;

    private readonly List<Product> basket;

    private static object syncRoot = new Object();

    private ProductsService()
    {
      this.basket = new List<Product>();
      this.products = new List<Product>();
      this.categories = new List<ProductType>();

      var phones = new ProductType() { Id = 1, Name = "phones", Title = "Телефоны" };
      var kitchen = new ProductType() { Id = 2, Name = "kitchen", Title = "Техника для кухни" };
      var toys = new ProductType() { Id = 3, Name = "toys", Title = "Игрушки" };
      var tvs = new ProductType() { Id = 4, Name = "tvs", Title = "Телевизоры" };
      var other = new ProductType() { Id = 5, Name = "other", Title = "Другое" };

      this.categories.Add(phones);
      this.categories.Add(kitchen);
      this.categories.Add(toys);
      this.categories.Add(tvs);
      this.categories.Add(other);


      var rnd = new Random();
      for (int i = 0; i < 100; i++)
      {
        // Сгенерировать для всех, кроме категории Other.
        int num = rnd.Next(0, 4);
        var category = this.categories[num];
        this.products.Add(
          new Product()
          {
            Id = i,
            Category = category,
            InBasket = false,
            Name = category.Title + " " + i.ToString(),
            Price = i * num * 100
          }
        );
      }
    }

    public static ProductsService GetInstance()
    {
      return instance;
    }

    public IEnumerable<ProductType> GetCategories() => categories;

    public IEnumerable<Product> GetProducts(ProductType type)
    {
      var items = products
        .Where(p => p.Category.Id == type.Id)
        .Select(product => {
          product.InBasket = basket.Any(b => b.Id == product.Id && b.Category.Id == product.Category.Id);
          return product;
        });

      return items;
    }

    public IEnumerable<Product> GetBasket() => basket;

    public void AddToBasket(Product product)
    {
      lock (syncRoot)
      {
        var prod = products.FirstOrDefault(x => x.Id == product.Id && x.Category.Id == product.Category.Id);
        if (prod == null)
          throw new ArgumentException(nameof(product));

        prod.InBasket = true;

        if (!basket.Any(x => x.Id == prod.Id && x.Category.Id == prod.Category.Id))
          basket.Add(prod);
      }
    }

    public void DeleteFromBasket(Product product)
    {
      lock (syncRoot)
      {
        var prod = products.FirstOrDefault(x => x.Id == product.Id && x.Category.Id == product.Category.Id);
        if (prod == null)
          throw new ArgumentException(nameof(product));

        prod.InBasket = true;

        var inBasketIndex = basket.FindIndex(x => x.Id == prod.Id && x.Category.Id == prod.Category.Id);
        if (inBasketIndex > -1)
        {
          basket.RemoveAt(inBasketIndex);
        }
      }
    }

    public ProductType GetProductType(int id)
    {
      return categories.First(x => x.Id == id);
    }
  }
}