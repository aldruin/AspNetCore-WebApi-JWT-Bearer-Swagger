
namespace CashFlowAPI.Application.Jwt.Dtos;
public class JwtDto
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public JwtDto(
        Guid id,
        string email
    )
    {
        Id = id;
        Email = email;
    }
}
