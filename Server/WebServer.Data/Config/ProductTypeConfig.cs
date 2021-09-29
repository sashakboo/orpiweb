using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebServer.Data.Entities;

namespace WebServer.Data.Config
{
  public class ProductTypeConfig : IEntityTypeConfiguration<ProductType>
  {
    public void Configure(EntityTypeBuilder<ProductType> builder)
    {
      builder.ToTable("ProductType");
      builder.Property(x => x.Name).IsRequired();
      builder.Property(x => x.Title).IsRequired();
    }
  }
}
