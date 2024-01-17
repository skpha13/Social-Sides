using backend.Models;
using backend.Models.DTOs.CommentDTOs;
using backend.Models.Responses;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class PostActionController : ControllerBase
    {
        private readonly IPostActionService _postActionService;
        private readonly UserManager<User> _userManager;

        public PostActionController(IPostActionService postActionService,
                                    UserManager<User> userManager)
        {
            _postActionService = postActionService;
            _userManager = userManager;
        }
        
        [Authorize]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [HttpPost("like/{postId}")]
        public async Task<IActionResult> LikePost(Guid postId)
        {
            var userId = _userManager.GetUserId(User);

            try
            {
                await _postActionService.LikePost(userId, postId);
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 400,
                    Message = exception.Message
                });
            }

            return Ok(new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Liked post"
            });
        }
        
        [Authorize]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [HttpDelete("unlike/{postId}")]
        public async Task<IActionResult> UnlikePost(Guid postId)
        {
            var userId = new Guid(_userManager.GetUserId(User));

            try
            {
                await _postActionService.UnlikePost(userId, postId);
                
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Unliked post"
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 400,
                    Message = exception.Message
                });
            }
        }

        [Authorize]
        [HttpPost("comment")]
        public async Task<IActionResult> CommentOnPost([FromBody] CreateCommentDTO commentDto)
        {
            var userId = _userManager.GetUserId(User);

            try
            {
                await _postActionService.CommentOnPost(userId, commentDto);
                
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Comment sent"
                });
            }
            catch (Exception exception)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 400,
                    Message = exception.Message
                });
            }
        }
    }
}
