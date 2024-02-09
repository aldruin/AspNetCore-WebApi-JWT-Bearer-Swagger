using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;
using CashFlowAPI.Infrastructure.Context;
using CashFlowAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlowAPI.Infrastructure.Repositories;
public class FinancialEntryRepository : Repository<FinancialEntry>, IFinancialEntryRepository
{
    public FinancialEntryRepository(AppDbContext context) : base(context)
    {
    }
    public async Task<ICollection<FinancialEntry>> GetEntriesBySheetIdAsync(Guid sheetId)
    {
        var entries = await Query.Cast<FinancialEntry>().Where(s => s.SheetId == sheetId).ToListAsync();
        return entries;
    }
}