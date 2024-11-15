using Annunci.Business.Abstractions;
using Annunci.Shared;
using Autenticazione.Http.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Autenticazione.Http;

namespace Annunci.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaritaController : ControllerBase
    {
        private readonly IBusiness _business;
        private readonly IClientHttp _authenticationClientHttp;

        public RaritaController(IBusiness business, IHttpContextAccessor context, IConfiguration configuration)
        {
            _business = business;
            _authenticationClientHttp = new ClientHttp(context, configuration);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddRarita(TipoRaritaDto rarita, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _authenticationClientHttp.IsAdmin();
            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei un admin");
            }
            try
            {
                await _business.AddRarita(rarita);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("getRarita")]
        public async Task<IActionResult> getRarita(CancellationToken cancellationToken = default)
        {

            try
            {
                
                return Ok(await _business.GetRarita());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}