namespace MicroserviceWebApi.Dtos
{
    public class AdjustProductStockQuantityToInHouseWarehouseDto
    {      
        public Dictionary<string, int> SkusQuantities { get; set; } 
        public long WarehouseId { get; set; }
        public bool IsCancelRequested { get; set; }
    }
}
