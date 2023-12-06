using CashFlowAPI.Domain.Entities;

namespace CashFlowAPI.Application.Dtos;
public class FinancialEntryDto
{
    public Guid SheetId { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string Category { get; set; }
    public DateOnly EntryDate { get; set; }
}