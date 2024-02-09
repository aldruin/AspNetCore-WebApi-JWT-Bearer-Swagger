using System.Security.Claims;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using CashFlowAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CashFlowAPI.Application.Services;
public sealed class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;
    private readonly ISheetRepository _sheetRepository;
    private readonly IFinancialEntryRepository _entryRepository;
    private readonly IFinancialExpenseRepository _expenseRepository;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository,
     ISheetRepository sheetRepository, IFinancialEntryRepository entryRepository, IFinancialExpenseRepository expenseRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
        _sheetRepository = sheetRepository;
        _entryRepository = entryRepository;
        _expenseRepository = expenseRepository;
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

    public async Task<bool> ValidateSheetAccess(Guid sheetId)
    {
        var currentUser = await GetCurrentUser();
        if (currentUser == null)
            return false;

        return await _sheetRepository.AnyAsync(s => s.UserId == currentUser.UserId);
    }
}