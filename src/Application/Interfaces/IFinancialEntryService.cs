using CashFlowAPI.Application.Dtos;

namespace CashFlowAPI.Application.Interfaces;
public interface IFinancialEntryService
{
    Task<FinancialEntryDto> CreateEntryAsync(FinancialEntryDto financialEntryDto);
    Task<FinancialEntryDto> UpdateEntryAsync(FinancialEntryDto financialEntryDto, Guid entryId);
    Task<FinancialEntryDto> DeleteEntryAsync(Guid entryId);
    Task<FinancialEntryDto> GetEntryById(Guid entryId);
    Task<List<FinancialEntryDto>> GetAllAsync();
}