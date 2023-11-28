

namespace CashFlowAPI.Application.Jwt.Dtos;
public class UserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string JwtToken { get; set; }
}
