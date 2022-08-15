using MicroserviceWebApi.SkubanaAccess.Abstracts;
using MicroserviceWebApi.SkubanaAccess.Configuration;
//using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using SkubanaAccess;
using SkubanaAccess.Authentication.Services;
using SkubanaAccess.Services.Authentication;
using SkubanaAccess.Services.Global;
using SkubanaAccess.Services.Inventory;
using SkubanaAccess.Services.Orders;
using SkubanaAccess.Services.Products;
using System.Configuration;

namespace MicroserviceWebApi
{
    public class Startup
    {
         
        public IConfiguration _config { get; }
        public SkubanaConfig _skubanaConfig { get; set; }
        public SkubanaAppCredentials _skubanaCredentials { get; set; }

        public Startup(IConfiguration config)
        {
            _config = config;

            SkubanaEnvironment environment =
                new SkubanaEnvironment(bool.Parse(config["useSandBox"]) == true ? SkubanaEnvironmentEnum.Sandbox : SkubanaEnvironmentEnum.Production,
                                       config["baseAuthUrl"], config["baseApiUrl"]);

            var accessToken = config["accessToken"];
            var skubanaUserCredentials = string.IsNullOrEmpty(accessToken) == true ? SkubanaUserCredentials.Blank : new SkubanaUserCredentials(accessToken);

            _skubanaConfig = new SkubanaConfig(environment, skubanaUserCredentials);


            var appKey = _config["applicationKey"];
            var appSecret = _config["appSecret"];
            var redirectUrl = _config["redirectUrl"];
            IEnumerable<SkubanaAppPermissionEnum> scopes = new List<SkubanaAppPermissionEnum>() { SkubanaAppPermissionEnum.ALL};

            _skubanaCredentials = new SkubanaAppCredentials(appKey, appSecret, redirectUrl, scopes);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Skubana services to DI container
            services.AddScoped<IAuthenticationService, AuthenticationService>(x => new AuthenticationService(_skubanaConfig, _skubanaCredentials));
            services.AddScoped<IGlobalService, GlobalService>(x => new GlobalService(_skubanaConfig));
            services.AddScoped<IOrdersService, OrdersService>(x => new OrdersService(_skubanaConfig));
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
