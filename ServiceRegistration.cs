using MicroserviceWebApi.SkubanaAccess.Abstracts;
using MicroserviceWebApi.SkubanaAccess.Configuration;
using SkubanaAccess.Services.Products;

namespace MicroserviceWebApi
{
    public static class ServiceRegistration
    {
        public static void AddSkubanaServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IProductsService, ProductsService>();
        }
    }
}
