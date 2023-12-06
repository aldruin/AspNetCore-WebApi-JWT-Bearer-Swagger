using CashFlowAPI.Application.Dtos.Jwt;

namespace CashFlowAPI.Application.Interfaces.Jwt;
public interface IJwtService
{
    Task<string> GenerateToken(JwtDto jwtDto);
    Task<JwtTokenViewDto> ReadTokenAsync(string token);
}