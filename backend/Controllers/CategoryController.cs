using backend.Models.DTOs;
using backend.Models.Responses;
using backend.Services.CategoryService;
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

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet("all")]
        [ProducesResponseType(typeof(List<CategoryDTO>), 200)]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryService.GetAllCategories());
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
        
        // TODO: get category with post includes/join
    }
}
