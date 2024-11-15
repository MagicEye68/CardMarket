using Recensioni.Business.Abstractions;
using Recensioni.Shared;
using Microsoft.AspNetCore.Mvc;
using Autenticazione.Http.Abstractions;
using Autenticazione.Http;

namespace Recensioni.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecensioneController : ControllerBase
    {
        private readonly IBusiness _business;
        private readonly IClientHttp _authenticationClientHttp;

        public RecensioneController(IBusiness business, IHttpContextAccessor context, IConfiguration configuration)
        {
            _business = business;
            _authenticationClientHttp = new ClientHttp(context, configuration);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddRecensione(RecensioneDto recensione, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _authenticationClientHttp.GetUserID();
            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei loggato");
            }
            try
            {
                await _business.AddRecensione(recensione,response.Content.ReadAsStringAsync().Result);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("delete")]
        public async Task<IActionResult> RemoveRecensione(int recensione, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage response = await _authenticationClientHttp.IsAdmin();
            if ((response.IsSuccessStatusCode))
            {
                await _business.RemoveRecensione(recensione, cancellationToken);
                return Ok();
            }
            response = await _authenticationClientHttp.GetUserID();
            if (!(response.IsSuccessStatusCode))
            {
                return Unauthorized("Non sei loggato");
            }
            string userid = response.Content.ReadAsStringAsync().Result;
            List<RecensioneReadDto> list = await _business.GetRecensioneByUtente(userid);
            foreach(RecensioneReadDto r in list)
            {
                if(r.Id == recensione)
                {
                    try
                    {
                        await _business.RemoveRecensione(recensione, cancellationToken);
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        return BadRequest(ex.Message);
                    }
                }
            }
            return Unauthorized();
        }

        [HttpGet("GetRecensioneByCompratore")]
        public async Task<IActionResult> GetRecensioneByUtente(string idUtente, CancellationToken cancellationToken = default)
        {
            try
            {

                return Ok(await _business.GetRecensioneByUtente(idUtente, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRecensioneByVenditore")]
        public async Task<IActionResult> GetRecensioneByVenditore(string idUtente, CancellationToken cancellationToken = default)
        {
            try
            {

                return Ok(await _business.GetRecensioneByVenditore(idUtente, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetVenditoriByMedia")]
        public async Task<IActionResult> GetVenditoriByMedia(double treshold, CancellationToken cancellationToken = default)
        {
            try
            {

                return Ok(await _business.GetMediaVenditori(treshold, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

