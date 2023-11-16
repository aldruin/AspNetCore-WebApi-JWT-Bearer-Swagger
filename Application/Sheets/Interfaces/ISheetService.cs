
using CashFlowAPI.Application.Sheets.Dtos;

namespace CashFlowAPI.Application.Sheets.Interfaces;
public interface ISheetService
{
    Task<SheetDto> CreateSheetAsync(SheetDto sheetDto);
    Task<List<SheetDto>> GetAllAsync();
    Task<SheetDto> GetByIdAsync(Guid sheetId);
    Task<SheetDto> UpdateByIdAsync(Guid sheetId, SheetDto sheetDto);
    Task<SheetDto> DeleteByIdAsync(Guid sheetId);
    
}