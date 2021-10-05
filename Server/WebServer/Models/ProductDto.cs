namespace WebServer.Models
{
  public class ProductDto
  {
    public int Id { get; set; }

    public ProductTypeDto Category { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }

    public bool InBasket { get; set; }
  }
}
