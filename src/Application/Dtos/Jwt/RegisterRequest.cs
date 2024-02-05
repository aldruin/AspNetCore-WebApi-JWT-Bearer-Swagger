namespace CashFlowAPI.Application.Dtos.Jwt;
public sealed class RegisterRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
