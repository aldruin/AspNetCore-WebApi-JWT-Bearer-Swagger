namespace CashFlowAPI.Application.Dtos.Jwt;
public class JwtDto
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Role { get; private set; }


    public JwtDto(Guid id, string email, string role)
    {
        Id = id;
        Email = email;
        Role = role;
    }
}
