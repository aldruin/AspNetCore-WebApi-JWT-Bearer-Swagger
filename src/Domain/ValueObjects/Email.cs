namespace CashFlowAPI.Domain.ValueObjects;
public sealed class Email
{
    public string Value { get; set; }
    public Email() { }
    public Email(string value)
    {
        this.Value = value ?? throw new ArgumentNullException(nameof(Email));
    }
}