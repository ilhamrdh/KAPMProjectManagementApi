using KAPMProjectManagementApi.Dto.Auth;

namespace KAPMProjectManagementApi.Interfaces.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequestDto request);
    }
}