using System.Text.Json.Serialization;

namespace CashFlowAPI.Domain.Entities;
public class Sheet : Entity
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public List<FinancialEntry> FinancialEntries { get; set; }
    public List<FinancialExpense> FinancialExpenses { get; set; }
    protected Sheet() { }
}