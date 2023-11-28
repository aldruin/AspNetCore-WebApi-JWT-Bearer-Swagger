
using CashFlowAPI.Domain.Entities;

namespace CashFlowAPI.Application.Finance.Dtos;
public class FinancialEntryDto
{
    public Guid? Id { get; set; }
    public Guid? SheetId { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string Category { get; set; }
    public DateOnly EntryDate { get; set; }
}