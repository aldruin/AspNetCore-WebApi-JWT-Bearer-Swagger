using CashFlowAPI.Domain.Base;
namespace CashFlowAPI.Domain.Entities;
public class FinancialEntry : Entity
{
    public Guid SheetId { get; set; }
    public Sheet Sheet { get; set; }
    public string Name { get; set; }
    public DateOnly EntryDate { get; set; }
    public decimal Value { get; set; }
    public string Caregory { get; set; }

    protected FinancialEntry() { }
}