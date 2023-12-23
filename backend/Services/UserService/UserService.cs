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
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<UserDTO> CreateAsync(UserCreateDTO user)
    {
        var userMapped = _mapper.Map<User>(user);
        await _userRepository.CreateAsync(userMapped);
        return _mapper.Map<UserDTO>(userMapped);
    }

    public async Task Update(UserDTO user)
    {
        var userMapped = _mapper.Map<User>(user);
        await _userRepository.Update(userMapped);
    }

    public async Task Delete(UserDTO user)
    {
        var userMapped = _mapper.Map<User>(user);
        await _userRepository.Delete(userMapped);
    }
}