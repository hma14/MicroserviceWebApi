using SkubanaAccess.Models;
using SkubanaAccess.Shared;

namespace MicroserviceWebApi.Dtos
{
    public class AdjustProductsStockQuantitiesDto
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public long WarehouseId { get; set; }
        public CancellationToken Token { get; set; } = CancellationToken.None;
        //public Mark Mark { get; set; } = null;

    }
}
