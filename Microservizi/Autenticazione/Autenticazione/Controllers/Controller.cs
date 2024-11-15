using Autenticazione.Business.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Autenticazione.Controllers
{
    public class Controller : ControllerBase
    {


        private readonly IBusiness business;

        public Controller(IBusiness business)
        {
            this.business = business;
        }

        [HttpGet("get_id")]
        public ActionResult<string> GetID()
        {
            string? email = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (email == null)
                return BadRequest("Non ho trovato l'ID");


            return email;
        }

        [HttpGet("is_admin")]
        public IActionResult IsAdmin()
        {
            if (User.IsInRole("Admin"))
            {
                return Ok();
            }
            else
            {
                return BadRequest("Non sei un admin");
            }
        }


        [HttpPost("give_role_admin")]
        public async Task<IActionResult> GiveAdmin()
        {
            try
            {
                string? email = GetID().Value;

                if (email == null)
                    return BadRequest("User non trovato");

                await business.GiveAdminRole(email);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
