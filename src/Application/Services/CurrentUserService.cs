using System.Security.Claims;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CashFlowAPI.Application.Services;
public sealed class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<CurrentUserDto> GetCurrentUser()
    {
        var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        var roleClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role);

        if (userIdClaim == null || roleClaim == null)
        {
            return null;
        }

        var currentUserId = Guid.Parse(userIdClaim.Value);
        var currentUserRole = roleClaim.Value;

        var currentUserDto = new CurrentUserDto
        {
            UserId = currentUserId,
            Role = currentUserRole,
        };
        return currentUserDto;
    }
}