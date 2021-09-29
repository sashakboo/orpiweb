namespace WebServer.Data.Entities
{
  public class Product
  {
    public virtual int Id { get; set; }

    public virtual ProductType Category { get; set; }

    public virtual string Name { get; set; }

    public virtual decimal Price { get; set; }

    public virtual bool InBasket { get; set; }
  }
}
