using CashFlowAPI.Application.Dtos;

namespace CashFlowAPI.Application.Interfaces;
public interface IUserService
{
    Task<UserDto> CreateUserAsync(UserDto userDto);
    Task<UserDto> UpdateUserAsync(UserDto userDto, Guid userId);
    Task<UserDto> DeleteUserAsync(Guid userId);
    Task<UserDto> GetUserById(Guid userId);
    Task<List<UserDto>> GetAllAsync();
}