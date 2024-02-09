using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]
public sealed class SheetController : ControllerBase
{
    private readonly ISheetService _sheetService;
    public SheetController(ISheetService sheetService)
    {
        _sheetService = sheetService;
    }

    [Authorize]
    [HttpPost("Create")]
    public async Task<IActionResult> CreateSheetAsync([FromBody] SheetDto sheetDto)
    {
        var newSheet = await _sheetService.CreateSheetAsync(sheetDto);
        return Ok(newSheet);
    }

    [Authorize]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllByUserIdAsync()
    {
        var sheets = await _sheetService.GetAllByUserIdAsync();
        if (sheets == null || !sheets.Any())
            return NotFound("Planilha não encontrada com o ID fornecido.");
        return Ok(sheets);
    }

    [Authorize]
    [HttpGet("Get/{sheetId}")]
    public async Task<IActionResult> GetByIdAsync(Guid sheetId)
    {
        var sheet = await _sheetService.GetByIdAsync(sheetId);
        if (sheet == null)
            return NotFound("Planilha não encontrada com o ID fornecido.");
        return Ok(sheet);
    }

    [Authorize]
    [HttpPut("Update/{sheetId}")]
    public async Task<IActionResult> UpdateByIdAsync(Guid sheetId, [FromBody] SheetDto sheetDto)
    {
        var sheet = await _sheetService.UpdateByIdAsync(sheetId, sheetDto);
        if (sheet == null)
            return NotFound("Planilha não encontrada com o ID fornecido.");
        return Ok(sheet);
    }

    [Authorize]
    [HttpDelete("Delete/{sheetId}")]
    public async Task<IActionResult> DeleteByIdAsync(Guid sheetId)
    {
        var sheet = await _sheetService.DeleteByIdAsync(sheetId);
        if (sheet == null)
            return NotFound("Planilha não encontrada com o ID fornecido.");
        return Ok("Planilha excluída com sucesso");
    }
}
