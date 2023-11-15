﻿
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.ValueObjects;

namespace CashFlowAPI.Application.Sheets.Dtos;
public class SheetDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; }
    public Guid UserId { get; set; }
    public List<FinancialEntry>? FinancialEntries { get; set; }
    public List<FinancialExpense>? FinancialExpenses { get; set; }
}