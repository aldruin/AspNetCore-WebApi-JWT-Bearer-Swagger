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
    private readonly ICurrentUserService _currentUserService;

    public SheetService(ISheetRepository sheetRepository, IMapper mapper, ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        _sheetRepository = sheetRepository;
        _mapper = mapper;
    }

    public async Task<SheetDto> CreateSheetAsync(SheetDto sheetDto)
    {
        if (sheetDto == null)
            throw new ArgumentNullException(nameof(sheetDto));

        var currentUser = await _currentUserService.GetCurrentUser();
        sheetDto.UserId = currentUser.UserId;
        var sheet = _mapper.Map<Sheet>(sheetDto);
        await _sheetRepository.AddAsync(sheet);
        return _mapper.Map<SheetDto>(sheet);
    }

    public async Task<SheetDto> GetByIdAsync(Guid sheetId)
    {
        if (sheetId == Guid.Empty)
            throw new ArgumentNullException(nameof(sheetId));

        if (!await _currentUserService.ValidateSheetAccess(sheetId))
            throw new UnauthorizedAccessException("Não é permitido acessar planilha de outro usuário.");

        var sheet = await _sheetRepository.GetByIdAsync(sheetId);
        return _mapper.Map<SheetDto>(sheet);
    }

    public async Task<List<SheetDto>> GetAllByUserIdAsync()
    {
        var currentUser = await _currentUserService.GetCurrentUser();
        var userId = currentUser.UserId;
        if (userId != currentUser.UserId)
            throw new UnauthorizedAccessException("Não é permitido acessar planilha de outro usuário.");

        var sheets = await _sheetRepository.GetSheetsByUserIdAsync(userId);
        return _mapper.Map<List<SheetDto>>(sheets);
    }

    public async Task<SheetDto> UpdateByIdAsync(Guid sheetId, SheetDto sheetDto)
    {
        if (sheetId == Guid.Empty || sheetDto == null)
            throw new ArgumentNullException(nameof(sheetDto), nameof(sheetId));

        if (!await _currentUserService.ValidateSheetAccess(sheetId))
            throw new UnauthorizedAccessException("Não é permitido acessar planilha de outro usuário.");

        var sheet = await _sheetRepository.GetByIdAsync(sheetId);
        sheet.Update(sheetDto.Name);
        await _sheetRepository.UpdateAsync(sheet);
        return _mapper.Map<SheetDto>(sheet);
    }
    public async Task<SheetDto> DeleteByIdAsync(Guid sheetId)
    {
        if (sheetId == Guid.Empty)
            throw new ArgumentNullException(nameof(sheetId));

        if (!await _currentUserService.ValidateSheetAccess(sheetId))
            throw new UnauthorizedAccessException("Não é permitido acessar planilha de outro usuário.");

        var sheet = await _sheetRepository.GetByIdAsync(sheetId);
        await _sheetRepository.DeleteAsync(sheetId);
        return null;
    }
}
