using CashFlowAPI.Application.Sheets.Dtos;
using CashFlowAPI.Application.Sheets.Interfaces;
using CashFlowAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]
//[Authorize]
public class SheetController : ControllerBase
{
    private readonly ISheetService _sheetService;

    public SheetController(ISheetService sheetService)
    {
        _sheetService = sheetService;
    }
    [HttpPost("Create")]
    public async Task<IActionResult> CreateSheetAsync([FromQuery] SheetDto sheetDto)
    {
        var newSheet = await _sheetService.CreateSheetAsync(sheetDto);
        return Ok(newSheet);
    }

    [HttpGet("GetAll")]
    public async Task <IActionResult> GetAllAsync()
    {
        var sheets = await _sheetService.GetAllAsync();
        if (sheets == null | !sheets.Any())
            return NotFound("Nenhuma planilha encontrada.");
        return Ok(sheets);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid sheetId)
    {
        var sheet = await _sheetService.GetByIdAsync(sheetId);
        if (sheet == null)
            return NotFound("Nenhuma planilha encontrada.");
        return Ok(sheet);
    }
    [HttpPut("UpdateById")]
    public async Task<IActionResult> UpdateByIdAsync(Guid sheetId, [FromQuery] SheetDto sheetDto)
    {
        var sheet = await _sheetService.UpdateByIdAsync(sheetId, sheetDto);
        if (sheet == null)
            return NotFound("Nenhuma planilha encontrada.");
        return Ok(sheet);
    }
    [HttpDelete("DeleteById")]
    public async Task<IActionResult>DeleteByIdAsync(Guid sheetId)
    {
        var sheet = await _sheetService.DeleteByIdAsync(sheetId);
        return Ok("Planilha excluida com sucesso");
    }
}