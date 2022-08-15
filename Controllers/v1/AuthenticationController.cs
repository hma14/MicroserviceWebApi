using MicroserviceWebApi.SkubanaAccess.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkubanaAccess.Models.Commands;
using SkubanaAccess.Models.Response;
using SkubanaAccess.Services.Authentication;

namespace MicroserviceWebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly IAuthenticationService service;

        public AuthenticationController(IConfiguration configuration, IAuthenticationService authenticationService)
        {
            config = configuration;
            service = authenticationService;
        }

        [ProducesResponseType(typeof(Response<IEnumerable<GetAccessTokenResponse>>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("GetAccessTokenAsync/{code}", Name = "GetAccessTokenAsync")]
        public async Task<GetAccessTokenResponse> GetAccessTokenAsync([FromRoute] string code, bool isCancelRequested = false)
        {
            CancellationToken token = isCancelRequested == true ? new CancellationToken(true) : CancellationToken.None;
            var result = await service.GetAccessTokenAsync(code, token);
            return result;
        }

        [ProducesResponseType(typeof(Response<IEnumerable<string>>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(500)]
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpGet("GetAppInstallationUrl", Name = "GetAppInstallationUrl")]
        public string GetAppInstallationUrl()
        {
            return service.GetAppInstallationUrl();
        }

    }

}
