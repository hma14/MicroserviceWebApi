using MicroserviceWebApi.Dtos;
using MicroserviceWebApi.SkubanaAccess.Configuration;
using MicroserviceWebApi.SkubanaAccess.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkubanaAccess.Models;
using SkubanaAccess.Services.Orders;

namespace MicroserviceWebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class OrdersController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IOrdersService service;
        public OrdersController(IConfiguration config, IOrdersService ordersService)
        {
            this.config = config;
            service = ordersService;
        }

        [ProducesResponseType(typeof(Response<IEnumerable<SkubanaOrder>>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("GetModifiedOrdersAsync", Name = "GetModifiedOrdersAsync")]
        public async Task<IEnumerable<SkubanaOrder>> GetModifiedOrdersAsync([FromBody] GetModifiedOrdersAsyncDto dto)
        {
            CancellationToken token = dto.IsCancelRequested == true ? new CancellationToken(true) : CancellationToken.None;
            return await service.GetModifiedOrdersAsync(dto.StartDateUtc, dto.EndDateUtc, dto.WarehouseId, token);
        }

    }
}
