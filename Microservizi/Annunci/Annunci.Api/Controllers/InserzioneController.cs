using Annunci.Business.Abstractions;
using Annunci.Shared;
using Autenticazione.Http.Abstractions;
using Autenticazione.Http;
using Microsoft.AspNetCore.Mvc;

namespace Annunci.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InserzioneController : ControllerBase
    {
        private readonly IBusiness _business;
        private readonly IClientHttp _authenticationClientHttp;


        public InserzioneController(IBusiness business, IHttpContextAccessor context, IConfiguration configuration)
        {
            _business = business;
            _authenticationClientHttp = new ClientHttp(context, configuration);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddInserzione(InserzioneInsertDto inserzione, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _authenticationClientHttp.GetUserID();
            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei loggato");
            }
            string userid = response.Content.ReadAsStringAsync().Result;

            InserzioneDto dto = new InserzioneDto
            {
                
                Venditore = userid,
                Carta = inserzione.Carta,
                Quantita = inserzione.Quantita,
                Prezzo = inserzione.Prezzo,
                Rarita = inserzione.Rarita

            };

            try
            {
                await _business.AddInserzione(dto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("delete")]
        public async Task<IActionResult> RemoveInserzione(int inserzione,int quantita, CancellationToken cancellationToken = default)
        {
           
            try
            {
                await _business.RemoveInserzione(inserzione,quantita,cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetInserzioneByCarta")]
        public async Task<IActionResult> GetInserzioneByCarta(string idCarta, CancellationToken cancellationToken = default)
        {
            try
            {

                return Ok(await _business.GetInserzioniByCarta(idCarta,cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetInserzioneByCartaRarita")]
        public async Task<IActionResult> GetInserzioneByCartaRarita(string idCarta, string Rarita, CancellationToken cancellationToken = default)
        {
            try
            {

                return Ok(await _business.GetInserzioniByCartaRarita(idCarta,Rarita, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetInserzioneByUtente")]
        public async Task<IActionResult> GetInserzioneByUtente(string id, CancellationToken cancellationToken = default)
        {
            try
            {

                return Ok(await _business.GetInserzioniByUtente(id, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}