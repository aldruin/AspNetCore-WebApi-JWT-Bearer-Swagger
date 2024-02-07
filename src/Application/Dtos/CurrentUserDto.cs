using CashFlowAPI.Domain.ValueObjects;

namespace CashFlowAPI.Application.Dtos;

public sealed class CurrentUserDto
{
    public Guid UserId { get; set; }
    public string Role { get; set; }
    public string Email { get; set; }
}