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

    [HttpPost("Create")]
    public async Task<IActionResult> CreateEntryAsync([FromQuery] FinancialEntryDto financialEntryDto)
    {
        if (financialEntryDto == null)
            return BadRequest("Dados de evento inválidos");
        var newEntry = await _financialEntryService.CreateEntryAsync(financialEntryDto);
        return Ok(newEntry);
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var entry = await _financialEntryService.GetAllAsync();
        if (entry == null | !entry.Any())
            return NotFound("Nenhum evento encontrado");
        return Ok(entry);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid entryId)
    {
        var entry = await _financialEntryService.GetEntryById(entryId);
        if (entry == null)
            return NotFound("O evento não foi encontrado");
        return Ok(entry);
    }

    [HttpPut("UpdateById")]
    public async Task<IActionResult> UpdateEntryAsync(Guid entryId, [FromQuery] FinancialEntryDto financialEntryDto)
    {
        var entryUpdated = await _financialEntryService.UpdateEntryAsync(financialEntryDto, entryId);
        return Ok(entryUpdated);
    }

    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteEntryAsync(Guid entryId)
    {
        var entry = await _financialEntryService.DeleteEntryAsync(entryId);
        return Ok("Evento excluido com sucesso");
    }
}