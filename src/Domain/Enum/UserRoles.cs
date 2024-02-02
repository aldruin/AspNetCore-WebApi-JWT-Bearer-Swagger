using System.ComponentModel;


namespace CashFlowAPI.Domain.Enum;
public enum UserRoles : int
{
    [Description("Admin")]
    Admin = 1,

    [Description("User")]
    User = 2,
}