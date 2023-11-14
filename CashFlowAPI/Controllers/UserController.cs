using CashFlowAPI.Application.Users.Dtos;
using CashFlowAPI.Application.Users.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[Controller]")]
[ApiController]
//[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController (IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateUserAsync([FromQuery] UserDto userdto)
    {
        try
        {
            if (userdto == null)
                return BadRequest("Dados de usuário inválidos");
            var newUser = await _userService.CreateUserAsync(userdto);
            return Ok(newUser);
        }
        catch(Exception ex) 
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno.");
        }

    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAllAsync()
    {
        var users = await _userService.GetAllAsync();
        if (users == null | !users.Any())
            return NotFound("Nenhum usuário encontrado");
        return Ok(users);
    }

    [HttpGet("GetById")]
    public async Task<IActionResult>GetByIdAsync(Guid id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
            return NotFound("O usuário não foi encontrado");
        return Ok(user);
    }

    [HttpPut("UpdateById")]
    public async Task<IActionResult>UpdateUserAsync(Guid id,[FromQuery] UserDto userdto)
    {
        var userUpdated = await _userService.UpdateUserAsync(userdto, id);
        return Ok(userUpdated);
    }

    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteUserAsync(Guid id)
    {
        try
        {
            var user = await _userService.DeleteUserAsync(id);
            return Ok("Usuario excluido com sucesso");
        }
        catch
        {
            return StatusCode(StatusCodes.Status400BadRequest, "Ocorreu um erro interno");
        }
    }
}