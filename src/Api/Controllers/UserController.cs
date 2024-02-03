using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]
//[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateUserAsync([FromQuery] UserDto userDto)
    {
        if (userDto == null)
            return BadRequest("Dados de usuário inválidos");
        var newUser = await _userService.CreateUserAsync(userDto);
        return Ok(newUser);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.GetAllAsync();
        if (users == null | !users.Any())
            return NotFound("Nenhum usuário encontrado");
        return Ok(users);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid userId)
    {
        var user = await _userService.GetUserById(userId);
        if (user == null)
            return NotFound("O usuário não foi encontrado");
        return Ok(user);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("UpdateById")]
    public async Task<IActionResult> UpdateUserAsync(Guid userId, [FromQuery] UserDto userDto)
    {
        var userUpdated = await _userService.UpdateUserAsync(userDto, userId);
        return Ok(userUpdated);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteUserAsync(Guid userId)
    {
        var user = await _userService.DeleteUserAsync(userId);
        return Ok("Usuario excluido com sucesso");
    }
}