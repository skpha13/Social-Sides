using backend.Models;
using backend.Models.DTOs.PostDTOs;
using backend.Repositories.GenericRepository;

namespace backend.Repositories.PostRepository;

public interface IPostRepository : IGenericRepository<Post>
{
    List<Post>  GetAllPostsWithIncludes(string? include);
    bool IsLikedBy(Guid userId, Guid postId);
    DeviceTokenDTO? GetUserNameDeviceToken(Guid postId);
}