using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;
using CashFlowAPI.Infrastructure.Context;
using CashFlowAPI.Infrastructure.Data;

namespace CashFlowAPI.Infrastructure.Repositories;
public class FinancialExpenseRepository : Repository<FinancialExpense>, IFinancialExpenseRepository
{
    public FinancialExpenseRepository(AppDbContext context) : base(context)
    {
    }
}