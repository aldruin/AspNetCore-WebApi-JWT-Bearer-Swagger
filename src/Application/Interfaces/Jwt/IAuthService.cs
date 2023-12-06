using CashFlowAPI.Application.Dtos.Jwt;

namespace CashFlowAPI.Application.Interfaces.Jwt;
public interface IAuthService
{
    Task<UserResponse> LoginAsync(LoginRequest request);
}
