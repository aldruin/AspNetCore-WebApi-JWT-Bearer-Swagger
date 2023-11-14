using AutoMapper;
using CashFlowAPI.Application.Users.Dtos;
using CashFlowAPI.Application.Users.Interfaces;
using CashFlowAPI.Domain.Entities;
using CashFlowAPI.Domain.Interfaces;
using CashFlowAPI.Domain.Security;

namespace CashFlowAPI.Application.Users.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService (IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUserAsync (UserDto userdto)
    {
        if (await _userRepository.AnyAsync(x => x.Name == userdto.Name))
            throw new Exception("O usuário já está cadastrado.");
        var user = _mapper.Map<User>(userdto);
        user.Validate();
        user.SetPassword(userdto.Password.Value);
        user.CreateAndAssociateSheet();
        await _userRepository.AddAsync(user);
        return _mapper.Map<UserDto>(user);
    }
    public async Task<UserDto> UpdateUserAsync (UserDto userdto, Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        user.Update(userdto.Name, userdto.Email, userdto.Password);
        user.Validate();
        user.SetPassword(userdto.Password.Value);
        if (user == null)
            throw new Exception("O usuario não foi encontrado.");
        await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserDto>(user);
    }
    public async Task<UserDto> DeleteUserAsync (Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new Exception("O usuario não foi encontrado.");
        await _userRepository.DeleteAsync(id);
        return null;
    }
    public async Task<UserDto> GetUserById (Guid id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new Exception("O usuario não foi encontrado.");
        return _mapper.Map<UserDto>(user);
    }
    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDto>>(users);
    }
}