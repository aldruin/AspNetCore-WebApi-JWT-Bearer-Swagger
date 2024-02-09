
using AutoMapper;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;

namespace CashFlowAPI.Application.Services;
public sealed class FinancialExpenseService : IFinancialExpenseService
{
    private readonly IFinancialExpenseRepository _financialExpenseRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public FinancialExpenseService(IFinancialExpenseRepository financialExpenseRepository, IMapper mapper, ICurrentUserService currentUserService)
    {
        _mapper = mapper;
        _financialExpenseRepository = financialExpenseRepository;
        _currentUserService = currentUserService;
    }
    public async Task<FinancialExpenseDto> CreateExpenseAsync(FinancialExpenseDto financialExpenseDto)
    {
        if (financialExpenseDto == null)
            throw new ArgumentNullException(nameof(financialExpenseDto));

        if (!await _currentUserService.ValidateSheetAccess(financialExpenseDto.SheetId))
            throw new UnauthorizedAccessException(nameof(financialExpenseDto));

        var expense = _mapper.Map<FinancialExpense>(financialExpenseDto);
        await _financialExpenseRepository.AddAsync(expense);
        return _mapper.Map<FinancialExpenseDto>(expense);


    }
    public async Task<FinancialExpenseDto> UpdateExpenseAsync(FinancialExpenseDto financialExpenseDto, Guid expenseId)
    {
        if (financialExpenseDto == null)
            throw new ArgumentNullException(nameof(financialExpenseDto));

        if (!await _currentUserService.ValidateSheetAccess(financialExpenseDto.SheetId))
            throw new UnauthorizedAccessException();

        var expense = await _financialExpenseRepository.GetByIdAsync(expenseId);
        decimal convertedValue = financialExpenseDto.ConvertValueToDecimal();
        expense.Update(financialExpenseDto.Name, convertedValue, financialExpenseDto.Category, financialExpenseDto.ExpenseDate);
        await _financialExpenseRepository.UpdateAsync(expense);
        return _mapper.Map<FinancialExpenseDto>(expense);
    }
    public async Task<FinancialExpenseDto> DeleteExpenseAsync(Guid expenseId)
    {
        if (expenseId == Guid.Empty)
            throw new ArgumentNullException(nameof(expenseId));

        var expense = await _financialExpenseRepository.GetByIdAsync(expenseId);
        if (!await _currentUserService.ValidateSheetAccess(expense.SheetId))
            throw new UnauthorizedAccessException();

        await _financialExpenseRepository.DeleteAsync(expenseId);
        return null;
    }
    public async Task<FinancialExpenseDto> GetExpenseById(Guid expenseId)
    {
        if (expenseId == Guid.Empty)
            throw new ArgumentNullException(nameof(expenseId));

        var expense = await _financialExpenseRepository.GetByIdAsync(expenseId);
        if (!await _currentUserService.ValidateSheetAccess(expense.SheetId))
            throw new UnauthorizedAccessException();

        return _mapper.Map<FinancialExpenseDto>(expense);
    }
    public async Task<List<FinancialExpenseDto>> GetAllAsync(Guid sheetId)
    {
        if (sheetId == Guid.Empty)
            throw new ArgumentNullException(nameof(sheetId));

        if (!await _currentUserService.ValidateSheetAccess(sheetId))
            throw new UnauthorizedAccessException();

        var expense = await _financialExpenseRepository.GetAllAsync();
        return _mapper.Map<List<FinancialExpenseDto>>(expense);
    }
}
