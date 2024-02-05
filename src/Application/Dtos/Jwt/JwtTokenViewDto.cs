namespace CashFlowAPI.Application.Dtos.Jwt;
public sealed class JwtTokenViewDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
}
