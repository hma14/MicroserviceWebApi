using SkubanaAccess.Authentication.Services;
using MicroserviceWebApi.SkubanaAccess.Configuration;
using SkubanaAccess.Services.Authentication;
using SkubanaAccess.Services.Global;
using SkubanaAccess.Services.Inventory;
using SkubanaAccess.Services.Orders;
using SkubanaAccess.Services.Products;
using System.Configuration;

namespace SkubanaAccess
{
	public class SkubanaFactory : ISkubanaFactory
	{
		public IAuthenticationService CreateAuthenticationService( SkubanaConfig config, SkubanaAppCredentials appCredentials )
		{
			return new AuthenticationService( config, appCredentials );
		}

		public IGlobalService CreateGlobalService( SkubanaConfig config )
		{
			return new GlobalService( config );
		}

		public IInventoryService CreateInventoryService( SkubanaConfig config )
		{
			return new InventoryService( config );
		}

		public IProductsService CreateProductsService( SkubanaConfig config )
		{
			return new ProductsService(config);
		}

		public IOrdersService CreateOrdersService( SkubanaConfig config )
		{
			return new OrdersService( config );
		}
	}
}