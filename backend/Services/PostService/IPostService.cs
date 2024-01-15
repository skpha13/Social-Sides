using backend.Models.DTOs;
using backend.Models.DTOs.PostDTOs;

namespace backend.Services.PostService;

public interface IPostService
{
    Task<List<PostDTO>> GetAllPosts();
    Task<bool> DeletePostById(Guid id);
    List<PostIncludesDTO> GetPostsWithIncludes(string? include);
    Task CreatePost(CreatePostUserDTO createPostDto);
    Task UpdatePost(UpdatePostDTO updatePostDto);
}