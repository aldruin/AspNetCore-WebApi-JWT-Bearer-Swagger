using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]
[Authorize]
public sealed class FinancialExpenseController : ControllerBase
{
    private readonly IFinancialExpenseService _financialExpenseService;

    public FinancialExpenseController(IFinancialExpenseService financialExpenseService)
    {
        _financialExpenseService = financialExpenseService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateExpenseAsync([FromQuery] FinancialExpenseDto financialExpenseDto)
    {
        if (financialExpenseDto == null)
            return BadRequest("Dados de evento inválidos");
        var newExpense = await _financialExpenseService.CreateExpenseAsync(financialExpenseDto);
        return Ok(newExpense);
    }


    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var expense = await _financialExpenseService.GetAllAsync();
        if (expense == null | !expense.Any())
            return NotFound("Nenhum evento encontrado");
        return Ok(expense);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid expenseId)
    {
        var expense = await _financialExpenseService.GetExpenseById(expenseId);
        if (expense == null)
            return NotFound("O evento não foi encontrado");
        return Ok(expense);
    }

    [HttpPut("UpdateById")]
    public async Task<IActionResult> UpdateEntryAsync(Guid expenseId, [FromQuery] FinancialExpenseDto financialExpenseDto)
    {
        var expenseUpdated = await _financialExpenseService.UpdateExpenseAsync(financialExpenseDto, expenseId);
        return Ok(expenseUpdated);
    }

    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteExpenseAsync(Guid expenseId)
    {
        var expense = await _financialExpenseService.DeleteExpenseAsync(expenseId);
        return Ok("Evento excluido com sucesso");
    }
}