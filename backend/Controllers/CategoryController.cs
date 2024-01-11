using backend.Models;
using backend.Models.DTOs;
using backend.Models.Responses;
using backend.Services.CategoryService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly UserManager<User> _userManager;

        public CategoryController(ICategoryService categoryService, UserManager<User> userManager)
        {
            _categoryService = categoryService;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet("all")]
        [ProducesResponseType(typeof(List<CategoryDTO>), 200)]
        public IActionResult GetCategories([FromQuery] string? include)
        {
            var userId = _userManager.GetUserId(User);
            return Ok(_categoryService.GetAllCategories(userId, include));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDTO categoryDto)
        {
            try
            {
                await _categoryService.CreateCategory(categoryDto);
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Category created successfully"
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

        [Authorize(Roles = "Admin")]
        [HttpPatch("update")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        public IActionResult UpdateCategory([FromBody] UpdateCategoryDTO updateCategoryDto)
        {
            _categoryService.UpdateCategory(updateCategoryDto);
            return Ok(new ErrorResponse()
            {
                StatusCode = 200,
                Message = "Category was updated successfully"
            });
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{id}")]
        [ProducesResponseType(typeof(ErrorResponse), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        public IActionResult DeleteCategoryById(Guid id)
        {
            var result = _categoryService.DeleteCategoryById(id);
            if (result == true)
                return Ok(new ErrorResponse()
                {
                    StatusCode = 200,
                    Message = "Category deleted successfully"
                });
            
            return BadRequest(new ErrorResponse()
            {
                StatusCode = 500,
                Message = "Category failed to be deleted"
            });
        }

        [Authorize]
        [HttpGet("all/with")]
        [ProducesResponseType(typeof(List<CategoryIdDTO>), 200)]
        public IActionResult GetCategoriesWithCreator([FromQuery] bool? user)
        {
            var userId = _userManager.GetUserId(User);
            return Ok(_categoryService.GetCategoriesWithCreator(new Guid(userId)));
        }
    }
}
