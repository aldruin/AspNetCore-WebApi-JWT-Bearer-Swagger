
using CashFlowAPI.Application.Users.Dtos;

namespace CashFlowAPI.Application.Users.Interfaces;
public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserDto userdto);
    Task<UserDto> UpdateUserAsync(UserDto userdto, Guid id);
    Task<UserDto> DeleteUserAsync(Guid id);
    Task<UserDto> GetUserById(Guid id);
    Task<List<UserDto>> GetAllAsync();
}