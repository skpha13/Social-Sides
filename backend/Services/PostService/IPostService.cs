using backend.Models.DTOs;

namespace backend.Services.PostService;

public interface IPostService
{
    Task<List<PostDTO>> GetAllPosts();
    Task<bool> DeletePostById(Guid id);
    List<PostIncludesDTO> GetPostsWithIncludes(string? include);
    Task CreatePost(CreatePostDTO createPostDto);
    Task UpdatePost(UpdatePostDTO updatePostDto);
}