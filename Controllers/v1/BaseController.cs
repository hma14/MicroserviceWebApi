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
            
        }
    }
}
