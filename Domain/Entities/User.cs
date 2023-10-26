using CashFlowAPI.Domain.Base;
namespace CashFlowAPI.Domain.Entities;
public class User : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Sheet Sheet { get; set; }


    protected User() { }
}