using Transazioni.Business.Abstractions;
using Transazioni.Shared;
using Autenticazione.Http.Abstractions;
using Autenticazione.Http;
using Microsoft.AspNetCore.Mvc;

namespace Transazioni.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IBusiness _business;
        private readonly IClientHttp _authenticationClientHttp;

        public PagamentoController(IBusiness business, IHttpContextAccessor context, IConfiguration configuration)
        {
            _business = business;
            _authenticationClientHttp = new ClientHttp(context, configuration);


        }
        [HttpPost("add")]
        public async Task<IActionResult> AddPagamento(PagamentoInsertDto pagamento, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _authenticationClientHttp.GetUserID();
            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei loggato");
            }
            string userid = response.Content.ReadAsStringAsync().Result;

            PagamentoDto dto = new PagamentoDto
            {
                Annuncio = pagamento.Annuncio,
                Compratore = userid,
                Metodo = pagamento.Metodo,
                Stato = pagamento.Stato
            };
            try
            {
                await _business.AddPagamento(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetPagamentoFromUtente")]
        public async Task<IActionResult> GetPagamentoFromUtente(string idUtente, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _authenticationClientHttp.IsAdmin();
            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei un admin");
            }
            try
            {

                return Ok(await _business.GetPagamentoFromUtente(idUtente, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPagamentoFromUtenteLoggato")]
        public async Task<IActionResult> GetPagamentoFromUtenteLoggato(CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _authenticationClientHttp.GetUserID();

            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei loggato");
            }

            string userid = response.Content.ReadAsStringAsync().Result;

            try
            {
                return Ok(await _business.GetPagamentoFromUtente(userid, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetPagamentoFromMetodo")]
        public async Task<IActionResult> GetPagamentoFromMetodo(string metodo, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _authenticationClientHttp.IsAdmin();
            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei un admin");
            }
            try
            {
                return Ok(await _business.GetPagamentoFromMetodo(metodo, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetPagamentoFromStato")]
        public async Task<IActionResult> GetPagamentoFromStato(string stato, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _authenticationClientHttp.IsAdmin();
            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei un admin");
            }
            try
            {

                return Ok(await _business.GetPagamentoFromStato(stato, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

