using backend.Models.DTOs;

namespace backend.Services.CategoryService;

public interface ICategoryService
{
    List<CategoryDTO> GetAllCategories(string userId, string? include);
    List<CategoryIdDTO> GetCategoriesWithCreator(Guid userId);
    Task CreateCategory(CreateCategoryDTO categoryDto);
    Task<bool> DeleteCategoryById(Guid id);
    Task UpdateCategory(UpdateCategoryDTO updateCategoryDto);
}