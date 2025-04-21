using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using QuickBooksIntegration.Models;
using QuickBooksIntegration.Services;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using VendorBillManagementAPI.Models;
using System.Text.Json; // Add this namespace for JSON deserialization

namespace QuickBooksIntegration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConnectionController : ControllerBase
    {
        private readonly QuickBooksSettings _settings;
        private readonly IConnectionService _connectionService;

        public ConnectionController(IOptions<QuickBooksSettings> options, IConnectionService connectionService)
        {
            _settings = options.Value;
            _connectionService = connectionService;
        }

        [HttpGet("connect")]
        public IActionResult Connect()
        {
            var scopes = "com.intuit.quickbooks.accounting";
            var authorizationUrl = $"https://appcenter.intuit.com/connect/oauth2?client_id={_settings.ClientId}&redirect_uri={_settings.RedirectUrl}&response_type=code&scope={scopes}&state=12345";
            return Ok(authorizationUrl);
        }

        [HttpGet("callback")]
        public async Task<IActionResult> Callback([FromQuery] string code, [FromQuery] string state, [FromQuery] string realmId)
        {
            if (string.IsNullOrEmpty(code) || string.IsNullOrEmpty(realmId))
            {
                return BadRequest("Missing required query parameters.");
            }

            try
            {
                using var httpClient = new HttpClient();
                var tokenRequest = new HttpRequestMessage(HttpMethod.Post, $"https://oauth.platform.intuit.com/oauth2/v1/tokens/bearer")
                {
                    Content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "authorization_code"),
                        new KeyValuePair<string, string>("code", code),
                        new KeyValuePair<string, string>("redirect_uri", _settings.RedirectUrl),
                        new KeyValuePair<string, string>("client_id", _settings.ClientId),
                        new KeyValuePair<string, string>("client_secret", _settings.ClientSecret)
                    })
                };

                var response = await httpClient.SendAsync(tokenRequest);
                response.EnsureSuccessStatusCode();

               

                // Replace the problematic line with the following code:
                var responseContent = await response.Content.ReadAsStringAsync();
                var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseContent);

              //  var tokenResponse = await response.Content.ReadAsAsync<TokenResponse>();
                await _connectionService.SaveQuickBooksAuthDetails(tokenResponse.AccessToken, tokenResponse.RefreshToken, realmId);

                return Ok("Authorization successful.");
            }
            catch (Exception ex)
            {
                // Log the error
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
