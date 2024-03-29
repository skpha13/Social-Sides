﻿using backend.Models;
using backend.Models.DTOs;
using backend.Models.DTOs.UserDTOs;
using backend.Models.Responses;

namespace backend.Services.UserService;

public interface IUserService
{
    Task<UserDTO> GetUserById(Guid id);
    Task<UserDTO> CreateAsync(UserCreateDTO user);
    Task Delete(Guid userId);
    Task<Guid> Login(LoginDTO loginModel);
    Task Logout();
    Task<ErrorResponse> SignUp(SignUpDTO signUpDto);
    Task<ErrorResponse> ConfirmEmail(string email, string token);
    Task StoreDeviceToken(string userId, string deviceToken);
    Task SaveAsync();
}