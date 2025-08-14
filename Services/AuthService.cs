using System.Text;
using System.Text.Json;
using KAPMProjectManagementApi.Dto.Auth;
using KAPMProjectManagementApi.Exceptions;
using KAPMProjectManagementApi.Interfaces.Auth;

namespace KAPMProjectManagementApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<AuthService> _logger;
        public AuthService(HttpClient httpClient, ILogger<AuthService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<LoginResponse> LoginAsync(LoginRequestDto request)
        {
            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://api.kai.id/kaisuperapps/auth/login", content);
            response.EnsureSuccessStatusCode();

            var stream = await response.Content.ReadAsStreamAsync();
            var external = await JsonSerializer.DeserializeAsync<LoginResponseExternal>(stream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return new LoginResponse
            {
                Token = external?.Data.Token ?? ""
            };
        }
    }
}