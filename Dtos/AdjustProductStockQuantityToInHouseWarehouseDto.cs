namespace MicroserviceWebApi.Dtos
{
    public class AdjustProductStockQuantityToInHouseWarehouseDto
    {      
        public Dictionary<string, int> SkusQuantities { get; set; } 
        public long WarehouseId { get; set; }
        public CancellationToken Token { get; set; }
    }
}
