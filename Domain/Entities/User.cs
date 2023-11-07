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
    public byte[] Salt { get; set; }
    public Sheet Sheet { get; set; }

    protected User() { }

    public void Validate() => new UserValidator().ValidateAndThrow(this);
    public void SetPassword(string newPassword, byte[] salt)
    {
        string hashedPassword = SecurityUtils.HashSHA256(newPassword, salt);
        Password = new Password(hashedPassword);
    }
    public void Update (string name, Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}