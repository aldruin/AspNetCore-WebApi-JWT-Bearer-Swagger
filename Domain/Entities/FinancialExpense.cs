namespace CashFlowAPI.Domain.Entities;
public class FinancialExpense : Entity
{
    public Guid SheetId { get; set; }
    public Sheet Sheet { get; set; }
    public string Name { get; set; }
    public DateOnly ExpenseDate { get; set; }
    public decimal Value { get; set; }
    public string Caregory { get; set; }

    protected FinancialExpense() { }
}