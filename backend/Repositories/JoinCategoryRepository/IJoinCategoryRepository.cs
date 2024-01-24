using backend.Models;

namespace backend.Repositories.JoinCategoryRepository;

public interface IJoinCategoryRepository
{
    Task CreateAsync(UserFollowsCategory entity);
    bool Delete(Guid userId, Guid categoryId);
    Task<bool> SaveAsync();
}