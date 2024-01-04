using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using backend.Models.DTOs.LikedDTOs;
using backend.Models.Responses;
using backend.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        
        [HttpPost("like/{postId}")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        public async Task<IActionResult> LikePost(Guid postId)
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return NotFound(new ErrorResponse()
                {
                    StatusCode = 404,
                    Message = "User not logged in"
                });
            }
            
            await _postActionService.LikePost(userId, postId);

            return Ok(new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Liked post"
            });
        }
    }
}
