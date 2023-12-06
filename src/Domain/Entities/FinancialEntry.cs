using CashFlowAPI.Domain.Common;
using CashFlowAPI.Domain.ValueObjects;

namespace CashFlowAPI.Domain.Entities;
public class FinancialEntry : Entity
{
    public Guid SheetId { get; set; }
    public Sheet Sheet { get; set; }
    public string Name { get; set; }
    public DateOnly EntryDate { get; set; }
    public decimal Value { get; set; }
    public string Category { get; set; }

    protected FinancialEntry() { }
    public void Update(string name, decimal value , string category, DateOnly entrydate)
    {
        Name = name;
        EntryDate = entrydate;
        Value = value;
        Category = category;
    }

}