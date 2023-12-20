using backend.Models.DTOs;

namespace backend.Services.PostService;

public interface IPostService
{
    Task<List<PostDTO>> GetAllPosts();
}