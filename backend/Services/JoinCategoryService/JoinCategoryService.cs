using AutoMapper;
using backend.Models;
using backend.Models.DTOs.UserFollowsCategoryDTOs;
using backend.Repositories.JoinCategoryRepository;

namespace backend.Services.JoinCategoryService;

public class JoinCategoryService: IJoinCategoryService
{
    private readonly IJoinCategoryRepository _joinCategoryRepository;
    private readonly IMapper _mapper;

    public JoinCategoryService(IJoinCategoryRepository joinCategoryRepository, IMapper mapper)
    {
        _joinCategoryRepository = joinCategoryRepository;
        _mapper = mapper;
    }
    public async Task JoinCategory(Guid userId, Guid categoryId)
    {
        await _joinCategoryRepository.CreateAsync(_mapper.Map<UserFollowsCategory>(new UserFollowsCategoryDTO()
        {
            CategoryId = categoryId,
            UserId = userId
        }));
        await _joinCategoryRepository.SaveAsync();
    }
}