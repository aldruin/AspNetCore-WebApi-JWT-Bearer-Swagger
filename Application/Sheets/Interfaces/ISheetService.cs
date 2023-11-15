
using CashFlowAPI.Application.Sheets.Dtos;

namespace CashFlowAPI.Application.Sheets.Interfaces;
public interface ISheetService
{
    Task<SheetDto> CreateSheetAsync(SheetDto sheetdto);
    Task<List<SheetDto>> GetAllAsync();
    
}