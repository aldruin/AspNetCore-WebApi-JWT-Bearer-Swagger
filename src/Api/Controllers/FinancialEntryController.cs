using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]
[Authorize]
public sealed class FinancialEntryController : ControllerBase
{
    private readonly IFinancialEntryService _financialEntryService;

    public FinancialEntryController(IFinancialEntryService financialEntryService)
    {
        _financialEntryService = financialEntryService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateEntryAsync([FromQuery] FinancialEntryDto financialEntryDto)
    {
        var newEntry = await _financialEntryService.CreateEntryAsync(financialEntryDto);
        return Ok(newEntry);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllAsync(Guid sheetId)
    {
        var entries = await _financialEntryService.GetAllAsync(sheetId);
        if (entries == null || !entries.Any())
        {
            return NotFound("Nenhuma entrada com este ID de planilha encontrada.");
        }

        return Ok(entries);
    }

    [HttpGet("get/{entryId}")]
    public async Task<IActionResult> GetByIdAsync(Guid entryId)
    {
        var entry = await _financialEntryService.GetEntryById(entryId);
        if (entry == null)
        {
            return NotFound("Nenhuma entrada com este ID encontrada.");
        }

        return Ok(entry);
    }

    [HttpPut("update/{entryId}")]
    public async Task<IActionResult> UpdateEntryAsync(Guid entryId, [FromQuery] FinancialEntryDto financialEntryDto)
    {
        var entryUpdated = await _financialEntryService.UpdateEntryAsync(financialEntryDto, entryId);
        if (entryUpdated == null)
        {
            return NotFound("Nenhuma entrada com este ID encontrada.");
        }

        return Ok(entryUpdated);
    }

    [HttpDelete("delete/{entryId}")]
    public async Task<IActionResult> DeleteEntryAsync(Guid entryId)
    {
        var entry = await _financialEntryService.DeleteEntryAsync(entryId);
        if (entry == null)
        {
            return NotFound("Nenhuma entrada com este ID encontrada.");
        }

        return Ok("Evento excluído com sucesso");
    }
}
