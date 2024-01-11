using backend.Models;

namespace backend.Repositories.JoinCategoryRepository;

public interface IJoinCategoryRepository
{
    Task CreateAsync(UserFollowsCategory entity);
    Task<bool> SaveAsync();
}