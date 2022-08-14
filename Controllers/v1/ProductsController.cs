using MicroserviceWebApi.Dtos;
using MicroserviceWebApi.SkubanaAccess.Abstracts;
using MicroserviceWebApi.SkubanaAccess.Configuration;
using MicroserviceWebApi.SkubanaAccess.Shared;
using Microsoft.AspNetCore.Mvc;
using SkubanaAccess.Exceptions;
using SkubanaAccess.Models;
using SkubanaAccess.Services.Products;
using SkubanaAccess.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MicroserviceWebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IProductsService service;
        public ProductsController(IConfiguration Configuration, IProductsService productsService)
        {
            config = Configuration;
            service = productsService;
        }

        [ProducesResponseType(typeof(Response<IEnumerable<SkubanaProduct>>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("GetProductsBySkus", Name = "GetProductsBySkus")]
        public async Task<IEnumerable<SkubanaProduct>> GetProductsBySkus([FromBody] GetProductsBySkusDto dto)
        {
            var skus = dto.Skus;
            var token = dto.Token;
            try
            {
                var result = await service.GetProductsBySkus(skus, token);
                return result;
            }
            catch (Exception ex)
            {
                throw new SkubanaException(ex.Message, ex.InnerException!);
            }
            
        }

        [ProducesResponseType(typeof(Response<IEnumerable<SkubanaProduct>>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("GetProductsUpdatedAfter", Name = "GetProductsUpdatedAfter")]
        public async Task<IEnumerable<SkubanaProduct>> GetProductsUpdatedAfter([FromBody] GetProductsUpdatedAfterDto dto)
        {
            var updatedAfterUtc = dto.UpdatedAfterUtc;
            var token = dto.Token;
            try
            {
                var result = await service.GetProductsUpdatedAfterAsync(updatedAfterUtc, token);
                return result;
            }
            catch (Exception ex)
            {
                throw new SkubanaException(ex.Message, ex.InnerException!);
            }

        }


    }
}
