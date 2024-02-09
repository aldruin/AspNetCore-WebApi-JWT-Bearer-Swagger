using AutoMapper;
using CashFlowAPI.Application.Dtos;
using CashFlowAPI.Application.Interfaces;
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Enum;
using CashFlowAPI.Domain.Interfaces;

namespace CashFlowAPI.Application.Services;
public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;

    public UserService(IUserRepository userRepository, IMapper mapper, ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUserAsync(UserDto userDto)
    {
        var currentUser = await _currentUserService.GetCurrentUser();
        if (userDto.Role == UserRoles.Admin && currentUser == null || userDto.Role == UserRoles.Admin && currentUser.Role != "Admin")
            throw new UnauthorizedAccessException("Usuário não tem permissão para criar um novo administrador.");

        if (await _userRepository.AnyAsync(x => x.Email.Value == userDto.Email.Value))
            throw new ArgumentException(nameof(userDto), "O email de usuário já está cadastrado.");

        var user = _mapper.Map<User>(userDto);
        user.Validate();
        user.SetPassword(userDto.Password.Value);
        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUserAsync(UserDto userDto, Guid userId)
    {
        var currentUser = await _currentUserService.GetCurrentUser();
        if (userId != currentUser.UserId && currentUser.Role != "Admin")
            throw new UnauthorizedAccessException("Somente administradores podem alterar outros usuários.");

        var user = await _userRepository.GetByIdAsync(userId);
        user.Update(userDto.Name, userDto.Email, userDto.Password);
        user.Validate();
        user.SetPassword(userDto.Password.Value);
        await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> DeleteUserAsync(Guid userId)
    {
        var currentUser = await _currentUserService.GetCurrentUser();
        if (userId != currentUser.UserId && currentUser.Role != "Admin")
            throw new UnauthorizedAccessException("Somente administradores podem deletar outros usuários.");

        var user = await _userRepository.GetByIdAsync(userId);
        await _userRepository.DeleteAsync(userId);
        return null;
    }

    public async Task<UserDto> GetUserById()
    {
        var currentUser = await _currentUserService.GetCurrentUser();
        var userId = currentUser.UserId;
        if (userId != currentUser.UserId && currentUser.Role != "Admin")
            throw new UnauthorizedAccessException("Somente administradores podem obter informações de outros usuários.");

        var user = await _userRepository.GetUserById(userId);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllUsers();
        return _mapper.Map<List<UserDto>>(users);
    }
}