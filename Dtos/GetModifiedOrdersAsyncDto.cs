namespace MicroserviceWebApi.Dtos
{
    public class GetModifiedOrdersAsyncDto
    {
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public int WarehouseId { get; set; }
        public bool IsCancelRequested { get; set; }

    }
}
