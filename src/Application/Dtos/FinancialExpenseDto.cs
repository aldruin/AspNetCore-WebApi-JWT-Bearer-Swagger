namespace CashFlowAPI.Application.Dtos;
public class FinancialExpenseDto
{
    public Guid SheetId { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string Category { get; set; }
    public DateOnly ExpenseDate { get; set; }
}
