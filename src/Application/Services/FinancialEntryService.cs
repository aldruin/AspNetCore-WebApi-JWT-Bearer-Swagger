using AutoMapper;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;

namespace CashFlowAPI.Application.Services;
public sealed class FinancialEntryService : IFinancialEntryService
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public FinancialEntryService(IFinancialEntryRepository financialEntryRepository, IMapper mapper, ICurrentUserService currentUserService)
    {
        _financialEntryRepository = financialEntryRepository;
        _mapper = mapper;
        _currentUserService = currentUserService;
    }

    public async Task<FinancialEntryDto> CreateEntryAsync(FinancialEntryDto financialEntryDto)
    {
        if (financialEntryDto == null)
            throw new ArgumentNullException(nameof(financialEntryDto));

        if (!await _currentUserService.ValidateSheetAccess(financialEntryDto.SheetId))
            throw new UnauthorizedAccessException();

        var entry = _mapper.Map<FinancialEntry>(financialEntryDto);
        await _financialEntryRepository.AddAsync(entry);
        return _mapper.Map<FinancialEntryDto>(entry);
    }

    public async Task<FinancialEntryDto> UpdateEntryAsync(FinancialEntryDto financialEntryDto, Guid entryId)
    {
        if (financialEntryDto == null)
            throw new ArgumentNullException(nameof(financialEntryDto));

        if (!await _currentUserService.ValidateSheetAccess(financialEntryDto.SheetId))
            throw new UnauthorizedAccessException();

        var entry = await _financialEntryRepository.GetByIdAsync(entryId);
        decimal convertedValue = financialEntryDto.ConvertValueToDecimal();
        entry.Update(financialEntryDto.Name, convertedValue, financialEntryDto.Category, financialEntryDto.EntryDate);
        await _financialEntryRepository.UpdateAsync(entry);
        return _mapper.Map<FinancialEntryDto>(entry);
    }

    public async Task<FinancialEntryDto> DeleteEntryAsync(Guid entryId)
    {
        if (entryId == Guid.Empty)
            throw new ArgumentNullException(nameof(entryId));

        var entry = await _financialEntryRepository.GetByIdAsync(entryId);
        if (!await _currentUserService.ValidateSheetAccess(entry.SheetId))
            throw new UnauthorizedAccessException();

        await _financialEntryRepository.DeleteAsync(entryId);
        return null;
    }

    public async Task<FinancialEntryDto> GetEntryById(Guid entryId)
    {
        if (entryId == Guid.Empty)
            throw new ArgumentNullException(nameof(entryId));

        var entry = await _financialEntryRepository.GetByIdAsync(entryId);
        if (!await _currentUserService.ValidateSheetAccess(entry.SheetId))
            throw new UnauthorizedAccessException();

        return _mapper.Map<FinancialEntryDto>(entry);
    }

    public async Task<List<FinancialEntryDto>> GetAllAsync(Guid sheetId)
    {
        if (sheetId == Guid.Empty)
            throw new ArgumentNullException(nameof(sheetId));

        if (!await _currentUserService.ValidateSheetAccess(sheetId))
            throw new UnauthorizedAccessException();

        var entry = await _financialEntryRepository.GetEntriesBySheetIdAsync(sheetId);
        return _mapper.Map<List<FinancialEntryDto>>(entry);
    }
}