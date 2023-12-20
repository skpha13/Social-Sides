using backend.Data;
using backend.Models;
using backend.Repositories.GenericRepository;

namespace backend.Repositories.PostRepository;

public class PostRepository : GenericRepository<Post>, IPostRepository
{
    public PostRepository(DatabaseContext dbContext) : base(dbContext) {}
}