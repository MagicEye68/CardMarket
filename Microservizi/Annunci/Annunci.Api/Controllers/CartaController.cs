using Annunci.Business.Abstractions;
using Annunci.Shared;
using Autenticazione.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Autenticazione.Http;
using Autenticazione.Http.Abstractions;

namespace Annunci.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartaController : ControllerBase
    {

        private readonly IBusiness _business;
        private readonly IClientHttp _authenticationClientHttp;


        public CartaController(IBusiness business, IHttpContextAccessor context, IConfiguration configuration)
        {
            _business = business;
            _authenticationClientHttp = new ClientHttp(context, configuration);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddCarta(CartaDto carta, CancellationToken cancellationToken = default)
        {

            HttpResponseMessage response = await _authenticationClientHttp.IsAdmin();
            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei un admin");
            }
            try
            {
                await _business.AddCarta(carta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetCartaByStringa")]
        public async Task<IActionResult> GetCartaByStringa(string stringa, CancellationToken cancellationToken = default)
        {
            try
            {

                return Ok(await _business.GetCartaByStringa(stringa, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

