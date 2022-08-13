using MicroserviceWebApi.SkubanaAccess.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkubanaAccess.Services.Products;

namespace MicroserviceWebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {
        protected readonly IConfiguration Configuration;

        public BaseController(IConfiguration Configuration)
        {
            this.Configuration = Configuration;

            //this.Configuration = Configuration ??
            //   throw new ArgumentNullException(nameof(Configuration));

            //SkubanaEnvironment environment =
            //    new SkubanaEnvironment(bool.Parse(Configuration["useSandBox"]) == true ? SkubanaEnvironmentEnum.Sandbox : SkubanaEnvironmentEnum.Production,
            //                           Configuration["baseAuthUrl"], Configuration["baseApiUrl"]);

            //var accessToken = Configuration["accessToken"];
            //SkubanaUserCredentials credentials = string.IsNullOrEmpty(accessToken) == true ? SkubanaUserCredentials.Blank : new SkubanaUserCredentials(accessToken);
            //_skubanaConfig = new SkubanaConfig(environment, credentials);
            
        }
    }
}
