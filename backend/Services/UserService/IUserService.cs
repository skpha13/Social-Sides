using backend.Models;
using backend.Models.DTOs;

namespace backend.Services.UserService;

public interface IUserService
{
    Task<UserDTO> GetUserById(Guid id);
    Task<UserDTO> CreateAsync(UserCreateDTO user);
    Task Update(UserDTO user);
    Task Delete(UserDTO user);
}