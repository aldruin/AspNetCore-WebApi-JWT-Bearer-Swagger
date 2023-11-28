using CashFlowAPI.Application.Jwt.Dtos;

namespace CashFlowAPI.Application.Jwt.Interfaces;
public interface IAuthService
{
    Task<UserResponse> LoginAsync(LoginRequest request);
}
