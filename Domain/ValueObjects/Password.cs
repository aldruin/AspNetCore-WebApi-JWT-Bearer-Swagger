namespace CashFlowAPI.Domain.ValueObjects;
public class Password
{
    public string Value { get; }

    public Password (string value)
    {
        this.Value = value ?? throw new ArgumentNullException(nameof(Password));
    }
}