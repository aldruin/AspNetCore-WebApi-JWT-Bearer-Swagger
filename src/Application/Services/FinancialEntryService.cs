using AutoMapper;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;

namespace CashFlowAPI.Application.Services;
public class FinancialEntryService : IFinancialEntryService
{
    private readonly IFinancialEntryRepository _financialEntryRepository;
    private readonly IMapper _mapper;

    public FinancialEntryService(IFinancialEntryRepository financialEntryRepository, IMapper mapper)
    {
        _financialEntryRepository = financialEntryRepository;
        _mapper = mapper;
    }

    public async Task<FinancialEntryDto> CreateEntryAsync(FinancialEntryDto financialEntryDto)
    {
        if (financialEntryDto.Value == null || financialEntryDto.Name == null || financialEntryDto.Category == null || financialEntryDto.SheetId == null)
            throw new Exception("Dados inválidos");
        var entry = _mapper.Map<FinancialEntry>(financialEntryDto);
        await _financialEntryRepository.AddAsync(entry);
        return _mapper.Map<FinancialEntryDto>(entry);


    }
    public async Task<FinancialEntryDto> UpdateEntryAsync(FinancialEntryDto financialEntryDto, Guid entryId)
    {
        if (financialEntryDto == null)
            throw new ArgumentNullException(nameof(financialEntryDto));
        
        var entry = await _financialEntryRepository.GetByIdAsync(entryId);

        if (entry == null)
            throw new Exception("O usuario não foi encontrado.");

        decimal convertedValue = financialEntryDto.ConvertValueToDecimal();

        entry.Update(financialEntryDto.Name, convertedValue, financialEntryDto.Category, financialEntryDto.EntryDate);
        await _financialEntryRepository.UpdateAsync(entry);
        return _mapper.Map<FinancialEntryDto>(entry);
    }
    public async Task<FinancialEntryDto> DeleteEntryAsync(Guid entryId)
    {
        var entry = await _financialEntryRepository.GetByIdAsync(entryId);
        if (entry == null)
            throw new Exception("Evento não encontrado");
        await _financialEntryRepository.DeleteAsync(entryId);
        return null;
    }
    public async Task<FinancialEntryDto> GetEntryById(Guid entryId)
    {
        var entry = await _financialEntryRepository.GetByIdAsync(entryId);
        if (entry == null)
            throw new Exception("Evento não encontrado");
        return _mapper.Map<FinancialEntryDto>(entry);
    }
    public async Task<List<FinancialEntryDto>> GetAllAsync()
    {
        var entry = await _financialEntryRepository.GetAllAsync();
        return _mapper.Map<List<FinancialEntryDto>>(entry);
    }
}