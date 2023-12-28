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
    
    public async Task<List<CategoryDTO>> GetAllCategories()
    {
        return _mapper.Map<List<CategoryDTO>>(await _categoryRepository.GetAllAsync());
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
        var category = _mapper.Map<Category>(updateCategoryDto);
        category.DateCreated = _categoryRepository.GetDateFromId(updateCategoryDto.Id);
        _categoryRepository.Update(_mapper.Map<Category>(category));
    }
}