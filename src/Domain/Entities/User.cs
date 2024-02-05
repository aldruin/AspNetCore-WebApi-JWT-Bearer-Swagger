using CashFlowAPI.Domain.Common;
using CashFlowAPI.Domain.Enum;
using CashFlowAPI.Domain.Rules;
using CashFlowAPI.Domain.Security;
using CashFlowAPI.Domain.ValueObjects;
using FluentValidation;

namespace CashFlowAPI.Domain.Entities;
public sealed class User : Entity
{
    public UserRoles Role { get; set; }
    public string Name { get; set; }
    public Email Email { get; set; }
    public Password Password { get; set; }
    public List<Sheet> Sheets { get; set; } = new List<Sheet>();
    public byte[] Salt { get; set; }

    protected User() { }

    public void SetPassword(string password)
    {
        byte[] salt = SecurityUtils.GenerateSalt();
        Salt = salt;
        Password.Value = SecurityUtils.HashSHA256(password, salt);
    }

    public void Validate() => new UserValidator().ValidateAndThrow(this);

    public void Update(string name, Email email, Password password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}
