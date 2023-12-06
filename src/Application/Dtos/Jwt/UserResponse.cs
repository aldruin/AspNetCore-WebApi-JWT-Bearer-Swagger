namespace CashFlowAPI.Application.Dtos.Jwt;
public class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string JwtToken { get; set; }
}
