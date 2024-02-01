
using AutoMapper;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;

namespace CashFlowAPI.Application.Services;
public class FinancialExpenseService : IFinancialExpenseService
{
    private readonly IFinancialExpenseRepository _financialExpenseRepository;
    private readonly IMapper _mapper;

    public FinancialExpenseService(IFinancialExpenseRepository financialExpenseRepository, IMapper mapper)
    {
        _mapper = mapper;
        _financialExpenseRepository = financialExpenseRepository;
    }
    public async Task<FinancialExpenseDto> CreateExpenseAsync(FinancialExpenseDto financialExpenseDto)
    {
        if (financialExpenseDto.Value == null || financialExpenseDto.Name == null || financialExpenseDto.Category == null || financialExpenseDto.SheetId == null)
            throw new Exception("Dados inválidos");
        var expense = _mapper.Map<FinancialExpense>(financialExpenseDto);
        await _financialExpenseRepository.AddAsync(expense);
        return _mapper.Map<FinancialExpenseDto>(expense);


    }
    public async Task<FinancialExpenseDto> UpdateExpenseAsync(FinancialExpenseDto financialExpenseDto, Guid expenseId)
    {
        if (financialExpenseDto == null)
            throw new ArgumentNullException(nameof(financialExpenseDto));

        var expense = await _financialExpenseRepository.GetByIdAsync(expenseId);

        if (expense == null)
            throw new Exception("O usuario não foi encontrado.");

        decimal convertedValue = financialExpenseDto.ConvertValueToDecimal();

        expense.Update(financialExpenseDto.Name, convertedValue, financialExpenseDto.Category, financialExpenseDto.ExpenseDate);
        await _financialExpenseRepository.UpdateAsync(expense);
        return _mapper.Map<FinancialExpenseDto>(expense);
    }
    public async Task<FinancialExpenseDto> DeleteExpenseAsync(Guid expenseId)
    {
        var expense = await _financialExpenseRepository.GetByIdAsync(expenseId);
        if (expense == null)
            throw new Exception("Evento não encontrado");
        await _financialExpenseRepository.DeleteAsync(expenseId);
        return null;
    }
    public async Task<FinancialExpenseDto> GetExpenseById(Guid expenseId)
    {
        var expense = await _financialExpenseRepository.GetByIdAsync(expenseId);
        if (expense == null)
            throw new Exception("Evento não encontrado");
        return _mapper.Map<FinancialExpenseDto>(expense);
    }
    public async Task<List<FinancialExpenseDto>> GetAllAsync()
    {
        var expense = await _financialExpenseRepository.GetAllAsync();
        return _mapper.Map<List<FinancialExpenseDto>>(expense);
    }
}
