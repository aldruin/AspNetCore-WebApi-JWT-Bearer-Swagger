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
    public async Task<IActionResult> CreateSheetAsync([FromQuery] SheetDto sheetdto)
    {
        var newSheet = await _sheetService.CreateSheetAsync(sheetdto);
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
}