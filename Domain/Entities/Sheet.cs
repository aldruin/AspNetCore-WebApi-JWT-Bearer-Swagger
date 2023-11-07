namespace CashFlowAPI.Domain.Entities;
public class Sheet : Entity
{
    public Guid UserId { get; set; }
    public User User { get; set; }
    public List<FinancialEntry> FinancialEntries { get; set; }
    public List<FinancialExpense> FinancialExpenses { get; set; }

    protected Sheet() { }
}