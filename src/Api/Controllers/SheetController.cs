using System.Security.Claims;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using CashFlowAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]
//[Authorize]
public sealed class SheetController : ControllerBase
{
    private readonly ISheetService _sheetService;
    private readonly IUserService _userService;

    public SheetController(ISheetService sheetService, IUserService userService)
    {
        _sheetService = sheetService;
        _userService = userService;
    }

    [Authorize]
    [HttpPost("Create")]
    public async Task<IActionResult> CreateSheetAsync([FromQuery] SheetDto sheetDto)
    {
        var newSheet = await _sheetService.CreateSheetAsync(sheetDto);
        return Ok(newSheet);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        //verifica se usuário é realmente Admin
        var sheets = await _sheetService.GetAllAsync();
        if (sheets == null | !sheets.Any())
            return NotFound("Nenhuma planilha encontrada.");
        return Ok(sheets);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid sheetId)
    {
        var userRole = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
        if (userRole != "Admin")
            return Unauthorized("Acesso negado");
        else if (userRole == null)
            return BadRequest("Ocorreu um erro interno.");
        else
        {
            var sheet = await _sheetService.GetByIdAsync(sheetId);
            if (sheet == null)
                return NotFound("Nenhuma planilha encontrada.");
            return Ok(sheet);
        }
    }

    [Authorize]
    [HttpGet("GetAllByUserId")]
    public async Task<IActionResult> GetAllByUserIdAsync()
    {
        Guid userId = Guid.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        var sheets = await _sheetService.GetAllByUserIdAsync(userId);
        if (sheets == null)
            return NotFound("Nenhuma planilha cadastrada");
        return Ok(sheets);
    }

    [Authorize]
    [HttpPut("UpdateById")]
    public async Task<IActionResult> UpdateByIdAsync(Guid sheetId, [FromQuery] SheetDto sheetDto)
    {
        var sheet = await _sheetService.UpdateByIdAsync(sheetId, sheetDto);
        if (sheet == null)
            return NotFound("Nenhuma planilha encontrada.");
        return Ok(sheet);
    }

    [Authorize]
    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteByIdAsync(Guid sheetId)
    {
        var sheet = await _sheetService.DeleteByIdAsync(sheetId);
        return Ok("Planilha excluida com sucesso");

    }
}