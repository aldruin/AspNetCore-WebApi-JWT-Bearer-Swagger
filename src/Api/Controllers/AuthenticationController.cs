using CashFlowAPI.Application.Jwt.Dtos;
using CashFlowAPI.Application.Jwt.Interfaces;
using CashFlowAPI.Application.Users.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlowAPI.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public AuthenticationController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromQuery] LoginRequest loginRequest)
    {
        try
        {
            var userRequest = await _authService.LoginAsync(loginRequest);
            if (userRequest == null)
            {
                return Unauthorized(new { ErrorMessage = "Usuário ou senha inválidos" });
            }
            return Ok(userRequest);
        }
        catch (Exception ex)
        {

            return BadRequest(new { ErrorMessage = ex.Message });
        }
    }
}
