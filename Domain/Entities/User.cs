using CashFlowAPI.Domain.Rules;
using CashFlowAPI.Domain.Security;
using CashFlowAPI.Domain.ValueObjects;
using FluentValidation;

namespace CashFlowAPI.Domain.Entities;
public class User : Entity
{
    public string Name { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }
    public Sheet Sheet { get; set; }
    public byte[] Salt { get; set; }

    public void CreateAndAssociateSheet()
    {
        Sheet = Sheet.CreateNewSheet(Id);
    }
    public void SetPassword(string password)
    {
        byte[] salt = SecurityUtils.GenerateSalt();
        this.Salt = salt;
        this.Password.Value = SecurityUtils.HashSHA256(password, salt);
    }
    public void Validate() => new UserValidator().ValidateAndThrow(this);
    public void Update (string name, Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;
    }

    protected User() { }

}