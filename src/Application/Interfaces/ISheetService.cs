using CashFlowAPI.Application.Dtos;

namespace CashFlowAPI.Application.Interfaces;
public interface ISheetService
{
    Task<SheetDto> CreateSheetAsync(SheetDto sheetDto);
    Task<List<SheetDto>> GetAllAsync();
    Task<List<SheetDto>> GetAllByUserIdAsync(Guid userId);
    Task<SheetDto> GetByIdAsync(Guid sheetId);
    Task<SheetDto> UpdateByIdAsync(Guid sheetId, SheetDto sheetDto);
    Task<SheetDto> DeleteByIdAsync(Guid sheetId);

}