using AutoMapper;
using backend.Models;
using backend.Models.DTOs;
using backend.Repositories.CategoryRepository;

namespace backend.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public List<CategoryDTO> GetAllCategories(string userId, string? include)
    {
        var categories = _categoryRepository.GetAllCategoriesWithIncludes(include);
        if (!string.IsNullOrEmpty(include))
        {
            categories = categories.Where(c => c.Users != null && c.Users.Any(u => u.UserId == new Guid(userId))).ToList();
        }
        return _mapper.Map<List<CategoryDTO>>(categories);
    }

    public async Task CreateCategory(CreateCategoryDTO categoryDto)
    {
        await _categoryRepository.CreateAsync(_mapper.Map<Category>(categoryDto));
    }

    public bool DeleteCategoryById(Guid id)
    {
        return _categoryRepository.DeleteById(id);
    }

    public void UpdateCategory(UpdateCategoryDTO updateCategoryDto)
    {
        // TODO: change how update works
        // if ca category has posts and users then when updating they will become null
        // because .NET update changes every field no matter what
        // IDEA: iterate trough fields and see which one proposes changes
        var category = _mapper.Map<Category>(updateCategoryDto);
        category.DateCreated = _categoryRepository.GetDateFromId(updateCategoryDto.Id);
        _categoryRepository.Update(_mapper.Map<Category>(category));
    }
}