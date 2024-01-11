namespace backend.Services.JoinCategoryService;

public interface IJoinCategoryService
{
    Task JoinCategory(Guid userId, Guid categoryId);
}