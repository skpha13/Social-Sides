using backend.Models;
using backend.Models.DTOs;
using backend.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace backend.Services.PostService;

public interface IPostService
{
    Task<List<PostDTO>> GetAllPosts();
    bool DeletePostById(Guid id);
    List<PostIncludesDTO> GetPostsWithIncludes(string include);
}