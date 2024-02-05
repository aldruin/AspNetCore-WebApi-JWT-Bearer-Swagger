using CashFlowAPI.Domain.Entities;

namespace CashFlowAPI.Application.Dtos;
public sealed class FinancialEntryDto
{
    public Guid SheetId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
    public string Category { get; set; }
    public DateOnly EntryDate { get; set; }

    public decimal ConvertValueToDecimal()
    {
        if (string.IsNullOrWhiteSpace(Value) || !decimal.TryParse(Value, out decimal convertedValue))
        {
            throw new ArgumentException("Formato de valor inválido ou valor ausente");
        }

        return convertedValue;
    }
}