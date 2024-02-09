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

    [HttpPost("create")]
    public async Task<IActionResult> CreateExpenseAsync([FromQuery] FinancialExpenseDto financialExpenseDto)
    {
        var newExpense = await _financialExpenseService.CreateExpenseAsync(financialExpenseDto);
        return Ok(newExpense);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAllAsync(Guid sheetId)
    {
        var expenses = await _financialExpenseService.GetAllAsync(sheetId);
        if (expenses == null || !expenses.Any())
        {
            return NotFound("Nenhum evento encontrado");
        }

        return Ok(expenses);
    }

    [HttpGet("get/{expenseId}")]
    public async Task<IActionResult> GetByIdAsync(Guid expenseId)
    {
        var expense = await _financialExpenseService.GetExpenseById(expenseId);
        if (expense == null)
        {
            return NotFound("O evento não foi encontrado");
        }

        return Ok(expense);
    }

    [HttpPut("update/{expenseId}")]
    public async Task<IActionResult> UpdateEntryAsync(Guid expenseId, [FromQuery] FinancialExpenseDto financialExpenseDto)
    {
        var expenseUpdated = await _financialExpenseService.UpdateExpenseAsync(financialExpenseDto, expenseId);
        if (expenseUpdated == null)
        {
            return NotFound("Nenhum evento encontrado para atualizar");
        }

        return Ok(expenseUpdated);
    }

    [HttpDelete("delete/{expenseId}")]
    public async Task<IActionResult> DeleteExpenseAsync(Guid expenseId)
    {
        var expense = await _financialExpenseService.DeleteExpenseAsync(expenseId);
        if (expense == null)
        {
            return NotFound("Nenhum evento encontrado para excluir");
        }

        return Ok("Evento excluído com sucesso");
    }
}
