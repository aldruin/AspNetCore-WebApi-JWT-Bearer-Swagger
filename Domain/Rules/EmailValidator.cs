using CashFlowAPI.Domain.ValueObjects;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CashFlowAPI.Domain.Rules;
public class EmailValidator : AbstractValidator<Email>
{
    private const string Pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

    public EmailValidator()
    {
        RuleFor(x => x.Value)
            .NotEmpty()
            .Must(BeValidEmail).WithMessage("Email inválido.");
    }
    private bool BeValidEmail(string value) => Regex.IsMatch(value, Pattern);
}