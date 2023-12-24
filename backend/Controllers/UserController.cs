using backend.Models.DTOs;
using backend.Models.Responses;
using backend.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet("user/{id}")]
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
                // TODO: see how to throw the result of identity to make better statuscodes
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = exception.Message
                });
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginBody)
        {
            try
            {
                return Ok(await _userService.Login(loginBody));
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
    }
}
