using backend.Data;
using backend.Models;
using backend.Repositories.PostRepository;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.PostActionService;

public class PostActionService : IPostActionService
{
    private readonly DatabaseContext _dbContext;
    private readonly DbSet<Liked> _table;
    private readonly IPostRepository _postRepository;

    public PostActionService(DatabaseContext dbContext,
                                IPostRepository postRepository)
    {
        _dbContext = dbContext;
        _table = _dbContext.Set<Liked>();
        _postRepository = postRepository;
    }

    public async Task LikePost(string userId, Guid postId)
    {
        await _table.AddAsync(new Liked()
        {
            UserId = new Guid(userId),
            PostId = postId
        });

        string username = _postRepository.GetAllPostsWithIncludes("user").Find(p => p.Id == postId).User.UserName;
        // TODO: send firebase notification to this user
        // TODO: store DeviceToken on User table
        // TODO: endpoint to store it
        
        await _dbContext.SaveChangesAsync();
    }
}