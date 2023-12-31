﻿using backend.Models.DTOs;

namespace backend.Services.CategoryService;

public interface ICategoryService
{
    List<CategoryDTO> GetAllCategories(string userId, string? include);
    Task CreateCategory(CreateCategoryDTO categoryDto);
    bool DeleteCategoryById(Guid id);
    void UpdateCategory(UpdateCategoryDTO updateCategoryDto);
}