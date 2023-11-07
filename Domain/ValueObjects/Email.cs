namespace CashFlowAPI.Domain.ValueObjects;
public class Email
{
    public string Value { get; }

    public Email(string value)
    {
        this.Value = value ?? throw new ArgumentNullException(nameof(Email));
    }
}