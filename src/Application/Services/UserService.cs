using AutoMapper;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;
using CashFlowAPI.Domain.Security;

namespace CashFlowAPI.Application.Services;
public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUserAsync(UserDto userDto)
    {
        if (await _userRepository.AnyAsync(x => x.Name == userDto.Name))
            throw new Exception("O usuário já está cadastrado.");
        var user = _mapper.Map<User>(userDto);
        user.Validate();
        user.SetPassword(userDto.Password.Value);
        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }
    public async Task<UserDto> UpdateUserAsync(UserDto userDto, Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        user.Update(userDto.Name, userDto.Email, userDto.Password);
        user.Validate();
        user.SetPassword(userDto.Password.Value);
        if (user == null)
            throw new Exception("O usuario não foi encontrado.");
        await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserDto>(user);
    }
    public async Task<UserDto> DeleteUserAsync(Guid userId)
    {
        var user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new Exception("O usuario não foi encontrado.");
        await _userRepository.DeleteAsync(userId);
        return null;
    }
    public async Task<UserDto> GetUserById(Guid userId)
    {
        var user = await _userRepository.GetUserById(userId);
        if (user == null)
            throw new Exception("O usuario não foi encontrado.");
        return _mapper.Map<UserDto>(user);
    }
    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllUsers();
        return _mapper.Map<List<UserDto>>(users);
    }
}