using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebServer.Data;
using WebServer.Services;

namespace WebServer
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers().AddJsonOptions(jsonOptions =>
        {
          jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
        }
      );

      var defaultConnection = this.Configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<ProductsContext>(x => x.UseSqlite(defaultConnection));
      services.AddAutoMapper(typeof(Startup).Assembly);
      services.AddScoped<IProductsRepository, ProductsRepository>();
      services.AddScoped<IProductsService, ProductsService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller}/{action}"
          );
      });
    }
  }
}
