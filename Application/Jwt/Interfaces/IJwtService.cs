using CashFlowAPI.Application.Jwt.Dtos;

namespace CashFlowAPI.Application.Jwt.Interfaces;
public interface IJwtService
{
    Task<string> GenerateToken(JwtDto jwtDto);
    Task<JwtTokenViewDto> ReadTokenAsync(string token);
}