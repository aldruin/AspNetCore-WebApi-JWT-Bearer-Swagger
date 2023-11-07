using CashFlowAPI.Domain.ValueObjects;

namespace CashFlowAPI.Domain.Entities;
public class User : Entity
{
    public string Name { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }
    public Sheet Sheet { get; set; }


    protected User() { }
}