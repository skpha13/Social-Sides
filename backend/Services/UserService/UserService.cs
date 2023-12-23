using System.Security.Claims;
using System.Text;
using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.Responses;
using backend.Repositories.UserRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContext; 

    public UserService(IUserRepository userRepository, 
                        IMapper mapper, 
                        UserManager<User> userManager,
                        IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userManager = userManager;
        _httpContext = httpContextAccessor;
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

        if (await _userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email)
            };
            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claimsIdentity = new ClaimsIdentity(authClaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            
            await _httpContext.HttpContext.SignInAsync (
                CookieAuthenticationDefaults.AuthenticationScheme,
                claimsPrincipal,
                new AuthenticationProperties
                {
                    IsPersistent = true, 
                    ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(3))
                });
            
            return new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Logged in successfully"
            };
        }
        return new ErrorResponse()
        {
            StatusCode = 500,
            Message = "Login failed"
        };
    }
}