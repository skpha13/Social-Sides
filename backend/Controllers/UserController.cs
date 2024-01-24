using backend.Helpers;
using backend.Models;
using backend.Models.DTOs;
using backend.Models.DTOs.UserDTOs;
using backend.Models.Responses;
using backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public UserController(IUserService userService, UserManager<User> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        
        [HttpGet("user/{id}")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                return Ok(await _userService.GetUserById(id));
            }
            catch (Exception exception)
            {
                return NotFound(new ErrorResponse()
                {
                    StatusCode = 404,
                    Message = exception.Message
                });
            }
            
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(UserCreateDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDTO user)
        {
            try
            {
                return Ok(await _userService.CreateAsync(user));
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message,
                });
            }
        }

        [Authorize]
        [HttpPatch("update")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDTO user)
        {
            try
            {
                return Ok(await _userService.Update(user));
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                   StatusCode = 500,
                   Message = exception.Message
                });
            }
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _userService.Delete(id);
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "User was deleted successfully"
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(ResponseLoginDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginBody)
        {
            try
            {
                return Ok(new ResponseLoginDTO()
                {
                    Id =  await _userService.Login(loginBody)
                });
            }
            catch (EmailNotFoundException exception)
            {
                return NotFound(new ErrorResponse()
                {
                    StatusCode = 404,
                    Message = exception.Message
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
        }

        [Authorize]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _userService.Logout();
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Logout was successful"
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
        }

        [AllowAnonymous]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [HttpPost("register")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDTO signUpDto)
        {
            try
            {
                return Ok(await _userService.SignUp(signUpDto));
            }
            catch (AccountAlreadyExistsException exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 400,
                    Message = exception.Message
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
        }

        [Authorize]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            var response = await _userService.ConfirmEmail(email, token);

            if (response.StatusCode == 200)
                return Ok(response);
            
            return BadRequest(response);
        }

        [Authorize]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [HttpPatch("device-token/{deviceToken}")]
        public async Task<IActionResult> StoreDeviceToken(string deviceToken)
        {
            string userId = _userManager.GetUserId(User);
            
            try
            {
                await _userService.StoreDeviceToken(userId, deviceToken);
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
            return Ok(new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Device token stored"
            });
        }

        [HttpGet("authenticated")]
        [ProducesResponseType(typeof(CheckLogin), 200)]
        public IActionResult CheckLogin()
        {
            bool isLoggedIn = User.Identity.IsAuthenticated;
            string userId = isLoggedIn ? _userManager.GetUserId(User) : "";

            return Ok(new CheckLogin()
            {
                IsLoggedIn = isLoggedIn,
                UserId = userId
            });
        }
        
        // TODO: Make a new Sendinblue account
        // TODO: get all posts from user
    }
}
