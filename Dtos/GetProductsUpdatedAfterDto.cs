namespace MicroserviceWebApi.Dtos
{
    public class GetProductsUpdatedAfterDto
    {
        public DateTime UpdatedAfterUtc { get; set; }
        public CancellationToken Token { get; set; } = CancellationToken.None;
    }
}
