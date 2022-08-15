using SkubanaAccess.Models;
using SkubanaAccess.Shared;

namespace MicroserviceWebApi.Dtos
{
    public class AdjustProductsStockQuantitiesDto
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public long WarehouseId { get; set; }
        public bool IsCancelRequested { get; set; }

    }
}
