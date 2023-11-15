using AutoMapper;
using CashFlowAPI.Application.Sheets.Dtos;
using CashFlowAPI.Application.Sheets.Interfaces;
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;

namespace CashFlowAPI.Application.Sheets.Services;
public class SheetService : ISheetService
{
    private readonly ISheetRepository _sheetRepository;
    private readonly IMapper _mapper;

    public SheetService(ISheetRepository sheetRepository, IMapper mapper)
    {
        _sheetRepository = sheetRepository;
        _mapper = mapper;
    }

    public async Task<SheetDto> CreateSheetAsync(SheetDto sheetdto)
    {
        if (sheetdto == null)
            throw new Exception("Insira um nome válido");
        var sheet = _mapper.Map<Sheet>(sheetdto);
        await _sheetRepository.AddAsync(sheet);
        return _mapper.Map<SheetDto>(sheet);
    }

    public async Task<List<SheetDto>> GetAllAsync()
    {
        var sheets = await _sheetRepository.GetAllAsync();
        return _mapper.Map<List<SheetDto>>(sheets);
    }
}
