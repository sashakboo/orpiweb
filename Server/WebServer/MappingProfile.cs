using AutoMapper;
using WebServer.Data.Entities;
using WebServer.Models;

namespace WebServer
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      this.CreateMap<Product, ProductDto>().ReverseMap();
      this.CreateMap<ProductType, ProductTypeDto>().ReverseMap();
    }
  }
}
