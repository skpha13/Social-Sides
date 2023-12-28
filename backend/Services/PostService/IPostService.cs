using backend.Models.DTOs;

namespace backend.Services.PostService;

public interface IPostService
{
    Task<List<PostDTO>> GetAllPosts();
    bool DeletePostById(Guid id);
    List<PostIncludesDTO> GetPostsWithIncludes(string? include);
}