using MicroserviceWebApi.SkubanaAccess.Abstracts;
using MicroserviceWebApi.SkubanaAccess.Configuration;
using Microsoft.AspNetCore.Builder;
using SkubanaAccess.Services.Inventory;
using SkubanaAccess.Services.Products;
using System.Configuration;

namespace MicroserviceWebApi
{
    public class Startup
    {
         
        public IConfiguration _config { get; }
        public SkubanaConfig _skubanaConfig { get; set; }

        public Startup(IConfiguration config)
        {
            _config = config;

            SkubanaEnvironment environment =
                new SkubanaEnvironment(bool.Parse(config["useSandBox"]) == true ? SkubanaEnvironmentEnum.Sandbox : SkubanaEnvironmentEnum.Production,
                                       config["baseAuthUrl"], config["baseApiUrl"]);

            var accessToken = config["accessToken"];
            SkubanaUserCredentials credentials = string.IsNullOrEmpty(accessToken) == true ? SkubanaUserCredentials.Blank : new SkubanaUserCredentials(accessToken);

            _skubanaConfig = new SkubanaConfig(environment, credentials);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddSkubanaServices(_config);
            services.AddScoped<IProductsService, ProductsService>(x => new ProductsService(_skubanaConfig));
            services.AddScoped<IInventoryService, InventoryService>(x => new InventoryService(_skubanaConfig));

            services.AddHealthChecks();


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
