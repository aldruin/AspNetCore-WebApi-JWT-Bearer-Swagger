using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]

public sealed class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUserAsync([FromQuery] UserDto userDto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Dados de usuário inválidos");

        var newUser = await _userService.CreateUserAsync(userDto);
        return Ok(newUser);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("users")]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.GetAllAsync();
        if (users == null || !users.Any())
            return NotFound("Nenhum usuário encontrado");
        return Ok(users);
    }

    [Authorize]
    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetByIdAsync(Guid userId)
    {
        var user = await _userService.GetUserById(userId);
        if (user == null)
            return NotFound("O usuário não foi encontrado");
        return Ok(user);
    }

    [Authorize]
    [HttpPut("users/{userId}")]
    public async Task<IActionResult> UpdateUserAsync(Guid userId, [FromQuery] UserDto userDto)
    {
        var userUpdated = await _userService.UpdateUserAsync(userDto, userId);
        return Ok(userUpdated);
    }

    [Authorize]
    [HttpDelete("users/{userId}")]
    public async Task<IActionResult> DeleteUserAsync(Guid userId)
    {
        var user = await _userService.DeleteUserAsync(userId);
        return Ok(new { Message = "Usuário excluído com sucesso" });
    }
}
