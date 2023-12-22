using backend.Models;
using backend.Models.DTOs;
using backend.Repositories.GenericRepository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories.PostRepository;

public interface IPostRepository : IGenericRepository<Post>
{
    List<Post>  GetAllPostsWithIncludes(string? include);
}