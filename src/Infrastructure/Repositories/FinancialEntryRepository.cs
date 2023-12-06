using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;
using CashFlowAPI.Infrastructure.Context;
using CashFlowAPI.Infrastructure.Data;

namespace CashFlowAPI.Infrastructure.Repositories;
public class FinancialEntryRepository : Repository<FinancialEntry>, IFinancialEntryRepository
{
    public FinancialEntryRepository(AppDbContext context) : base(context)
    {
    }
}