using CashFlowAPI.Domain.Entities;

namespace CashFlowAPI.Domain.Interfaces;
public interface IFinancialEntryRepository : IRepository<FinancialEntry>
{
    Task<ICollection<FinancialEntry>> GetEntriesBySheetIdAsync(Guid sheetId);

}