using CashFlowAPI.Domain.ValueObjects;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CashFlowAPI.Domain.Rules;
public sealed class PasswordValidator : AbstractValidator<Password>
{
    private const string Pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";

    public PasswordValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty()
            .Must(BeValidPassword).WithMessage("A Senha deve ter no mínimo 8 caracteres, uma letra, um caracter especial e um número.");
    }
    private bool BeValidPassword(string value) => Regex.IsMatch(value, Pattern);
}