using MicroserviceWebApi.SkubanaAccess.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkubanaAccess.Models;
using SkubanaAccess.Services.Global;
using SkubanaAccess.Shared;
using System.ComponentModel.DataAnnotations;

namespace MicroserviceWebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class GlobalController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IGlobalService service;

        public GlobalController(IConfiguration config, IGlobalService globalService)
        {
            this.config = config;
            service = globalService;
        }

        [ProducesResponseType(typeof(Response<IEnumerable<SkubanaWarehouse>>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("ListWarehouses/{isCancelRequested:bool}", Name = "ListWarehouses")]
        public async Task<IEnumerable<SkubanaWarehouse>> ListWarehouses([FromRoute] bool isCancelRequested, Mark? mark = null)
        {
            CancellationToken token = isCancelRequested == true ? new CancellationToken(true) : new CancellationToken(false);
            return await service.ListWarehouses(token, mark);
        }
    }
}
