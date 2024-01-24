using backend.Models;
using backend.Models.DTOs;
using backend.Models.Responses;
using backend.Services.JoinCategoryService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class CategoryActionController : ControllerBase
    {
        private readonly IJoinCategoryService _joinCategoryService;
        private readonly UserManager<User> _userManager;

        public CategoryActionController(UserManager<User> userManager, IJoinCategoryService joinCategoryService)
        {
            _userManager = userManager;
            _joinCategoryService = joinCategoryService;
        }

        [Authorize]
        [HttpPost("join")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        public async Task<IActionResult> JoinCategory([FromBody] JoinCategoryDTO category)
        {
            var userId = _userManager.GetUserId(User);
            var categoryId = category.Id;

            await _joinCategoryService.JoinCategory(new Guid(userId), categoryId);
            return Ok(new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Joined category"
            });
        }

        [Authorize]
        [HttpDelete("unfollow")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public async Task<IActionResult> UnjoinCategory([FromBody] JoinCategoryDTO category)
        {
            var userId = new Guid(_userManager.GetUserId(User));
            var categoryId = category.Id;

            var result = await _joinCategoryService.UnjoinCategory(userId, categoryId);

            return result
                ? Ok(new ErrorResponse() { StatusCode = 200, Message = "Unfollowed Category" })
                : BadRequest(new ErrorResponse() { StatusCode = 400, Message = "Error encounterd" });
        }
    }
}
