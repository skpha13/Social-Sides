using backend.Models.DTOs;

namespace backend.Services.CategoryService;

public interface ICategoryService
{
    Task<List<CategoryDTO>> GetAllCategories();
    Task CreateCategory(CreateCategoryDTO categoryDto);
    bool DeleteCategoryById(Guid id);
    void UpdateCategory(UpdateCategoryDTO updateCategoryDto);
}