using MicroserviceWebApi.SkubanaAccess.Abstracts;
using MicroserviceWebApi.SkubanaAccess.Configuration;
using Microsoft.AspNetCore.Builder;
using SkubanaAccess.Services.Products;

namespace MicroserviceWebApi
{
    public class Startup
    {

        public IConfiguration _config { get; }

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSkubanaServices(_config);
            //services.AddScoped<IProductsService, ProductsService>();


        }

        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/api/health");
                endpoints.MapControllers();
            });

        }
    }
}
