using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebServer.Data.Entities;

namespace WebServer.Data.Config
{
  public class ProductConfig : IEntityTypeConfiguration<Product>
  {
    public  void Configure(EntityTypeBuilder<Product> builder)
    {
      builder.ToTable("Product");
      builder.Property(x => x.Name).IsRequired();
      builder.Property(x => x.Price).IsRequired();
      builder.Property(x => x.InBasket).IsRequired();

      builder.HasOne(x => x.Category).WithMany().IsRequired();
    }
  }
}
