
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.ValueObjects;
using System.Text.Json.Serialization;

namespace CashFlowAPI.Application.Sheets.Dtos;
public class SheetDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public Guid UserId { get; set; }
    [JsonIgnore]
    public List<FinancialEntry>? FinancialEntries { get; set; }
    [JsonIgnore]
    public List<FinancialExpense>? FinancialExpenses { get; set; }
}