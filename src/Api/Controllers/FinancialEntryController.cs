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

    [HttpPost("entries")]
    public async Task<IActionResult> CreateEntryAsync([FromQuery] FinancialEntryDto financialEntryDto)
    {
        if (financialEntryDto == null)
        {
            return BadRequest("Dados de evento inválidos");
        }

        var newEntry = await _financialEntryService.CreateEntryAsync(financialEntryDto);
        return Ok(newEntry);
    }

    [HttpGet("entries")]
    public async Task<IActionResult> GetAllAsync()
    {
        var entries = await _financialEntryService.GetAllAsync();
        if (entries == null || !entries.Any())
        {
            return NotFound("Nenhum evento encontrado");
        }

        return Ok(entries);
    }

    [HttpGet("entries/{entryId}")]
    public async Task<IActionResult> GetByIdAsync(Guid entryId)
    {
        var entry = await _financialEntryService.GetEntryById(entryId);
        if (entry == null)
        {
            return NotFound("O evento não foi encontrado");
        }

        return Ok(entry);
    }

    [HttpPut("entries/{entryId}")]
    public async Task<IActionResult> UpdateEntryAsync(Guid entryId, [FromQuery] FinancialEntryDto financialEntryDto)
    {
        var entryUpdated = await _financialEntryService.UpdateEntryAsync(financialEntryDto, entryId);
        if (entryUpdated == null)
        {
            return NotFound("Nenhum evento encontrado para atualizar");
        }

        return Ok(entryUpdated);
    }

    [HttpDelete("entries/{entryId}")]
    public async Task<IActionResult> DeleteEntryAsync(Guid entryId)
    {
        var entry = await _financialEntryService.DeleteEntryAsync(entryId);
        if (entry == null)
        {
            return NotFound("Nenhum evento encontrado para excluir");
        }

        return Ok("Evento excluído com sucesso");
    }
}
