using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]
//[Authorize]
public sealed class SheetController : ControllerBase
{
    private readonly ISheetService _sheetService;
    public SheetController(ISheetService sheetService)
    {
        _sheetService = sheetService;
    }

    [HttpPost("sheets")]
    public async Task<IActionResult> CreateSheetAsync([FromQuery] SheetDto sheetDto)
    {
        var newSheet = await _sheetService.CreateSheetAsync(sheetDto);
        return Ok(newSheet);
    }

    [HttpGet("sheets")]
    public async Task<IActionResult> GetAllAsync()
    {
        var sheets = await _sheetService.GetAllAsync();
        if (sheets == null || !sheets.Any())
            return NotFound("Nenhuma planilha encontrada.");
        return Ok(sheets);
    }

    [HttpGet("sheets/{sheetId}")]
    public async Task<IActionResult> GetByIdAsync(Guid sheetId)
    {
        var sheet = await _sheetService.GetByIdAsync(sheetId);
        if (sheet == null)
            return NotFound("Nenhuma planilha encontrada.");
        return Ok(sheet);
    }

    [HttpPut("sheets/{sheetId}")]
    public async Task<IActionResult> UpdateByIdAsync(Guid sheetId, [FromQuery] SheetDto sheetDto)
    {
        var sheet = await _sheetService.UpdateByIdAsync(sheetId, sheetDto);
        if (sheet == null)
            return NotFound("Nenhuma planilha encontrada.");
        return Ok(sheet);
    }

    [HttpDelete("sheets/{sheetId}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid sheetId)
    {
        var sheet = await _sheetService.DeleteByIdAsync(sheetId);
        if (sheet == null)
            return NotFound("Nenhuma planilha encontrada.");
        return Ok("Planilha excluída com sucesso");
    }
}
