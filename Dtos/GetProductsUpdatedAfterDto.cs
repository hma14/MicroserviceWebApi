namespace MicroserviceWebApi.Dtos
{
    public class GetProductsUpdatedAfterDto
    {
        public DateTime UpdatedAfterUtc { get; set; }
        public bool IsCancelRequested { get; set; }
    }
}
