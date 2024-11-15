using Autenticazione.Http.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Autenticazione.Http
{
    public class ClientHttp : IClientHttp
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ClientHttp(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            _httpClient = new()
            {
                BaseAddress = new("http://" + configuration.GetSection("AuthenticationServiceBaseAddressHttp").Value + "/"),
            };

            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<HttpResponseMessage> IsAdmin(CancellationToken cancellationToken = default)
        {
            HttpRequestMessage req = new(HttpMethod.Get, "is_admin");

            foreach (string? cookie in _httpContextAccessor.HttpContext.Request.Headers["Cookie"])
                req.Headers.Add("Cookie", cookie);

            return await _httpClient.SendAsync(req, cancellationToken);

        }

        public async Task<HttpResponseMessage> GetUserID(CancellationToken cancellationToken = default)
        {
            HttpRequestMessage req = new(HttpMethod.Get, "get_id");

            foreach (string? cookie in _httpContextAccessor.HttpContext.Request.Headers["Cookie"])
                req.Headers.Add("Cookie", cookie);

            return await _httpClient.SendAsync(req, cancellationToken);
        }
    }
}

