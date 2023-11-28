using CashFlowAPI.Application.Finance.Dtos;

namespace CashFlowAPI.Application.Finance.Interfaces;
public interface IFinancialExpenseService
{
    Task<FinancialExpenseDto> CreateExpenseAsync(FinancialExpenseDto financialExpenseDto);
    Task<FinancialExpenseDto> UpdateExpenseAsync(FinancialExpenseDto financialExpenseDto, Guid expenseId);
    Task<FinancialExpenseDto> DeleteExpenseAsync(Guid expenseId);
    Task<FinancialExpenseDto> GetExpenseById(Guid expenseId);
    Task<List<FinancialExpenseDto>> GetAllAsync();
}
