using AutoMapper;
using backend.Helpers;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.DTOs.UserDTOs;
using backend.Models.Responses;
using backend.Repositories.UserRepository;
using Microsoft.AspNetCore.Identity;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Client;
using sib_api_v3_sdk.Model;
using Task = System.Threading.Tasks.Task;

namespace backend.Services.UserService;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IConfiguration _configuration;

    public UserService(IUserRepository userRepository, 
                        IMapper mapper, 
                        UserManager<User> userManager,
                        SignInManager<User> signInManager,
                        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
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

    public async Task<Guid> Login(LoginDTO loginDto)
    {
        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        if (user == null)
        {
            throw new EmailNotFoundException("Email not found");
        }
        
        var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: true);

            return user.Id;
        }

        throw new Exception("Wrong Password");
    }

    public async Task Logout()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<ErrorResponse> SignUp(SignUpDTO signUpDto)
    {
        var existsUser = await _userManager.FindByEmailAsync(signUpDto.Email);

        if (existsUser != null)
            return new ErrorResponse()
            {
                StatusCode = 400,
                Message = "An account with this email already exists"
            };

        var user = _mapper.Map<User>(signUpDto);
        var result = await _userManager.CreateAsync(user);
        if (result.Succeeded)
        {
            await _userManager.AddToRoleAsync(user, "User");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var apiKey = _configuration["SMTPApiKey"];
            
            Configuration.Default.ApiKey.Add("api-key", apiKey);
            var apiInstance = new TransactionalEmailsApi();
            string senderName = "Social-Sides";
            string senderEmail = "admin@social-sides.com";
            SendSmtpEmailSender emailSender = new SendSmtpEmailSender(senderName, senderEmail);

            SendSmtpEmailTo smtpEmailTo = new SendSmtpEmailTo(user.Email, user.UserName);
            List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
            To.Add(smtpEmailTo);

            string HtmlContent =
                "<!DOCTYPE html>\n<html>\n<head>\n  <meta charset=\"UTF-8\">\n  <title>Email Confirmation</title>\n  <style>\n    body {\n      font-family: Arial, sans-serif;\n      margin: 0;\n      padding: 0;\n      background-color: #f4f4f4;\n    }\n    .container {\n      max-width: 600px;\n      margin: 20px auto;\n      padding: 20px;\n      background-color: #fff;\n      border-radius: 8px;\n      box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);\n    }\n    h1 {\n      color: #333;\n    }\n    p {\n      color: #555;\n    }\n  </style>\n</head>\n<body>\n  <div class=\"container\">\n    <h1>Email Confirmation</h1>\n    <p>Dear {{sendName}},</p>\n    <p>Thank you for registering. Please use the following code to validate your email:</p>\n    <p style=\"font-size: 18px; background-color: #f7f7f7; padding: 10px; border-radius: 5px;\"><strong>{{token}}</strong></p>\n    <p>Copy and paste the code manually.</p>\n  </div>\n</body>\n</html>\n";
            HtmlContent = HtmlContent.Replace("{{sendName}}", senderName).Replace("{{token}}",token);
            
            string TextContent = $"Your code for email validations is: {token}";
            string Subject = "Email confirmation";
   
            var sendSmtpEmail = new SendSmtpEmail(emailSender, To, null, null, HtmlContent, TextContent, Subject);
            CreateSmtpEmail sent = apiInstance.SendTransacEmail(sendSmtpEmail);
  
            return new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Register was successful"
            };
        }
        throw new Exception(result.Errors.First().Description);
    }

    public async Task<ErrorResponse> ConfirmEmail(string email, string token)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return new ErrorResponse()
            {
                StatusCode = 400,
                Message = "There is no user with this email"
            };
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (result.Succeeded)
        {
            return new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Confirmation successfull"
            };
        }
        
        return new ErrorResponse()
        {
            StatusCode = 500,
            Message = "Confirmation failed"
        };
    }

    public async Task StoreDeviceToken(string userId, string deviceToken)
    {
        var existingUser = await _userRepository.GetUserById(new Guid(userId));
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        existingUser.DeviceToken = deviceToken;
        await _userRepository.Update(existingUser);
    }
}