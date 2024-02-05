using CashFlowAPI.Domain.Common;

namespace CashFlowAPI.Domain.Entities;
public sealed class FinancialExpense : Entity
{
    public Guid SheetId { get; set; }
    public Sheet Sheet { get; set; }
    public string Name { get; set; }
    public DateOnly ExpenseDate { get; set; }
    public decimal Value { get; set; }
    public string Category { get; set; }

    protected FinancialExpense() { }
    public void Update(string name, decimal value, string category, DateOnly expensedate)
    {
        Name = name;
        ExpenseDate = expensedate;
        Value = value;
        Category = category;
    }
}