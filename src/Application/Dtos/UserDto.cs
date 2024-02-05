using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Enum;
using CashFlowAPI.Domain.ValueObjects;

namespace CashFlowAPI.Application.Dtos;
public sealed class UserDto
{
    public Guid? Id { get; set; }
    public UserRoles Role { get; set; }
    public string Name { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }
    //public List<Sheet>? Sheets { get; set; }
    public List<string>? Sheets { get; set; }
}