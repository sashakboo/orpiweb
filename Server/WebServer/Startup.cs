using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
      services.AddEntityFrameworkSqlite().AddDbContext<ProductsContext>();
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

      app.UseAuthorization();

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
