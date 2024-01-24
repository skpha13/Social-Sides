namespace backend.Services.JoinCategoryService;

public interface IJoinCategoryService
{
    Task JoinCategory(Guid userId, Guid categoryId);
    Task<bool> UnjoinCategory(Guid userId, Guid categoryId);
}