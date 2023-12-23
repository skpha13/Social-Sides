using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
using backend.Repositories.UserRepository;

namespace backend.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDTO> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null) throw new Exception("User not found");
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> CreateAsync(UserCreateDTO user)
    {
        var userMapped = _mapper.Map<User>(user);
        await _userRepository.CreateAsync(userMapped);
        return _mapper.Map<UserDTO>(userMapped);
    }

    public async Task<UserDTO> Update(UserUpdateDTO user)
    {
        var existingUser = await _userRepository.GetUserById(user.Id);

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (user.UserName != null) existingUser.UserName = user.UserName;
        if (user.Email != null) existingUser.Email = user.Email;
        if (user.Password != null) existingUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
        
        await _userRepository.Update(existingUser);
        return _mapper.Map<UserDTO>(existingUser);
    }

    public async Task Delete(Guid userId)
    {
        await _userRepository.Delete(userId);
    }
}