using backend.Models;
using backend.Models.DTOs;
using backend.Models.Responses;

namespace backend.Services.UserService;

public interface IUserService
{
    Task<UserDTO> GetUserById(Guid id);
    Task<UserDTO> CreateAsync(UserCreateDTO user);
    Task<UserDTO> Update(UserUpdateDTO user);
    Task Delete(Guid userId);
    Task<ErrorResponse> Login(LoginDTO loginModel);
    Task Logout();
    Task<ErrorResponse> SignUp(SignUpDTO signUpDto);
    Task<ErrorResponse> ConfirmEmail(string email, string token);
}