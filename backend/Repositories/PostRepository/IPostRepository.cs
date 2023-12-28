using backend.Models;
using backend.Repositories.GenericRepository;

namespace backend.Repositories.PostRepository;

public interface IPostRepository : IGenericRepository<Post>
{
    List<Post>  GetAllPostsWithIncludes(string? include);
}