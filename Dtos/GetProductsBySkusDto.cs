using SkubanaAccess.Shared;

namespace MicroserviceWebApi.Dtos
{
    public class GetProductsBySkusDto
    {
        public IEnumerable<string> Skus { get; set; }
        public bool IsCancelRequested { get; set; }

    }
}
