using CashFlowAPI.Application.Jwt.Dtos;
using CashFlowAPI.Application.Jwt.Interfaces;
using CashFlowAPI.Domain.Interfaces;
namespace CashFlowAPI.Application.Jwt.Services;
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;

    public AuthService(IUserRepository userRepository, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<UserResponse> LoginAsync(LoginRequest request)
    {
        var user = await _userRepository.GetByExpressionAsync(x => x.Email.Value == request.Email);
        if (user == null) { return null; }
        var jwtToken = await _jwtService.GenerateToken(new JwtDto(user.Id, user.Email.Value));

        return new UserResponse
        {
            Id = user.Id,
            Email = user.Email.Value,
            JwtToken = jwtToken,
        };
    }
}
