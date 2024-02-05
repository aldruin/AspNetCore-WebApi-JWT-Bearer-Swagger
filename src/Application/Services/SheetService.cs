using AutoMapper;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;

namespace CashFlowAPI.Application.Services;
public sealed class SheetService : ISheetService
{
    private readonly ISheetRepository _sheetRepository;
    private readonly IMapper _mapper;

    public SheetService(ISheetRepository sheetRepository, IMapper mapper)
    {
        _sheetRepository = sheetRepository;
        _mapper = mapper;
    }

    public async Task<SheetDto> CreateSheetAsync(SheetDto sheetDto)
    {
        if (sheetDto == null)
            throw new Exception("Insira um nome válido");
        var sheet = _mapper.Map<Sheet>(sheetDto);
        await _sheetRepository.AddAsync(sheet);
        return _mapper.Map<SheetDto>(sheet);
    }

    public async Task<List<SheetDto>> GetAllAsync()
    {
        var sheets = await _sheetRepository.GetAllAsync();
        return _mapper.Map<List<SheetDto>>(sheets);
    }
    public async Task<SheetDto> GetByIdAsync(Guid sheetId)
    {
        var sheet = await _sheetRepository.GetByIdAsync(sheetId);
        return _mapper.Map<SheetDto>(sheet);
    }
    public async Task<List<SheetDto>> GetAllByUserIdAsync(Guid userId)
    {
        var sheets = await _sheetRepository.GetSheetsByUserIdAsync(userId);
        return _mapper.Map<List<SheetDto>>(sheets);
    }
    public async Task<SheetDto> UpdateByIdAsync(Guid sheetId, SheetDto sheetDto)
    {
        var sheet = await _sheetRepository.GetByIdAsync(sheetId);
        sheet.Update(sheetDto.Name);
        await _sheetRepository.UpdateAsync(sheet);
        return _mapper.Map<SheetDto>(sheet);
    }
    public async Task<SheetDto> DeleteByIdAsync(Guid sheetId)
    {
        var sheet = await _sheetRepository.GetByIdAsync(sheetId);
        if (sheet == null)
            throw new Exception("A planilha não foi encontrada");
        await _sheetRepository.DeleteAsync(sheetId);
        return null;
    }
}
