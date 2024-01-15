using backend.Models;
using backend.Models.DTOs;
using backend.Models.DTOs.PostDTOs;
using backend.Models.Responses;
using backend.Services.PostService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly UserManager<User> _userManager;

        public PostController(IPostService postService, UserManager<User> userManager)
        {
            _postService = postService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("all")]
        [ProducesResponseType(typeof(PostIncludesDTO), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public IActionResult GetPostWithIncludes([FromQuery] string? include)
        {
            var posts = _postService.GetPostsWithIncludes(include);
            if (posts.Any())
            {
                return Ok(posts);
            }

            return NotFound(new ErrorResponse()
            {
                StatusCode = 404,
                Message = "Nu au fost gasite postari"
            });
        }
        
        [Authorize]
        [HttpGet("posts")]
        [ProducesResponseType(typeof(List<PostDTO>), 200)]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }
        
        [Authorize]
        [HttpDelete("posts/{postId}")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> DeletePost(Guid postId)
        {
            var deleted = await _postService.DeletePostById(postId);
            if (deleted == false)
            {
                return BadRequest(new ErrorResponse()
                {
                    StatusCode = 500,
                    Message = "Post was not deleted"
                });
            }

            return Ok(new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Post was deleted"
            });
        }

        [Authorize]
        [HttpPost("create")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDTO createPostDto)
        {
            var userId = new Guid(_userManager.GetUserId(User));
            var payload = new CreatePostUserDTO()
            {
                Text = createPostDto.Text,
                CategoryId = new Guid(createPostDto.CategoryId),
                UserId = userId
            };
            
            await _postService.CreatePost(payload);
            return Ok(new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Post created successfully"
            });
        }
        
        [Authorize]
        [HttpPatch("update")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDTO updatePostDto)
        {
            try
            {
                await _postService.UpdatePost(updatePostDto);
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Post updated successfully"
                });
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
    }
}
