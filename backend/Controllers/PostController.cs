using backend.Services.PostService;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("posts")]
        public IActionResult GetAllPosts()
        {
            return Ok(_postService.GetAllPosts());
        }
    }
}
