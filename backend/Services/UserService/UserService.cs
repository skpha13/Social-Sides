using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.Responses;
using backend.Repositories.UserRepository;
using Microsoft.AspNetCore.Identity;

namespace backend.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public UserService(IUserRepository userRepository, 
                        IMapper mapper, 
                        UserManager<User> userManager,
                        SignInManager<User> signInManager)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
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
        
        var hasher = new PasswordHasher<User>();
        if (user.UserName != null) existingUser.UserName = user.UserName;
        if (user.Email != null) existingUser.Email = user.Email;
        if (user.Password != null) existingUser.PasswordHash = hasher.HashPassword(null, user.Password);
        
        await _userRepository.Update(existingUser);
        return _mapper.Map<UserDTO>(existingUser);
    }

    public async Task Delete(Guid userId)
    {
        await _userRepository.Delete(userId);
    }

    public async Task<ErrorResponse> Login(LoginDTO loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null)
        {
            return new ErrorResponse()
            {
                StatusCode = 404,
                Message = "Email not found"
            };
        }
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: true);
            
            return new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Login successfull"
            };
        }

        return new ErrorResponse()
        {
            StatusCode = 500,
            Message = "Login failed"
        };
    }
}