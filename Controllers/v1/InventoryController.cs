using MicroserviceWebApi.Dtos;
using MicroserviceWebApi.SkubanaAccess.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SkubanaAccess.Models;
using SkubanaAccess.Services.Inventory;
using SkubanaAccess.Services.Products;

namespace MicroserviceWebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InventoryController : BaseController
    {
        private readonly IInventoryService service;
        public InventoryController(IConfiguration Configuration) : base(Configuration)
        {
            service = new InventoryService(skubanaConfig);
        }

        [ProducesResponseType(typeof(Response<IEnumerable<AdjustProductStockQuantityResponse>>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("AdjustProductStockQuantityTo3PLWarehouse", Name = "AdjustProductStockQuantityTo3PLWarehouse")]
        public async Task<AdjustProductStockQuantityResponse> AdjustProductStockQuantityTo3PLWarehouse([FromBody] AdjustProductsStockQuantitiesDto dto)
        {
            var sku = dto.Sku;
            var quantity = dto.Quantity;
            var warehouseId = dto.WarehouseId;
            var token = dto.Token;
            //var mark = dto.Mark;
            try
            {
                var result = await service.AdjustProductStockQuantityTo3PLWarehouse(sku, quantity, warehouseId, token);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [ProducesResponseType(typeof(Response<IEnumerable<AdjustProductStockQuantityResponse>>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("AdjustProductsStockQuantitiesTo3PLWarehouse", Name = "AdjustProductsStockQuantitiesTo3PLWarehouse")]
        public async Task<AdjustProductStockQuantityResponse> AdjustProductsStockQuantitiesTo3PLWarehouse([FromBody] AdjustProductStockQuantityToInHouseWarehouseDto dto)
        {

            var skusQuantities = dto.SkusQuantities; 
            var warehouseId = dto.WarehouseId;
            var token = dto.Token;
            try
            {
                var result = await service.AdjustProductsStockQuantitiesTo3PLWarehouse(skusQuantities, warehouseId, token);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
