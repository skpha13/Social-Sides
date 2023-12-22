using backend.Models.Responses;
using backend.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> GetAllPosts()
        {
            var posts = await _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("posts/{postId}")]
        public IActionResult GetPostWithIncludes(Guid postId, [FromQuery] string? include)
        {
            var posts = _postService.GetPostsWithIncludes(include);
            if (posts.Any())
            {
                var post = posts.FirstOrDefault(post => post.Id == postId);
                return Ok(post);
            }

            return NotFound(new ErrorResponse()
            {
                StatusCode = 404,
                Message = "Nu au fost gasite postari"
            });
        }

        [HttpDelete("posts/{postId}")]
        public IActionResult DeletePost(Guid postId)
        {
            var deleted = _postService.DeletePostById(postId);
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
    }
}
