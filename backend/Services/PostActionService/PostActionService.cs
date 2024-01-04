using backend.Data;
using backend.Models;
using backend.Repositories.PostRepository;
using Microsoft.EntityFrameworkCore;
using FirebaseAdmin.Messaging;

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

        Post post = _postRepository.GetAllPostsWithIncludes("user").Find(p => p.Id == postId);

        if (post == null)
        {
            throw new Exception("Invalid request");
        }

        var messageToSend = new Message()
        {
            Notification = new Notification()
            {
                Title = "Social-Sides",
                Body = $"{post.User.UserName} liked your post!"
            },
            Token = post.User.DeviceToken
        };

        var messaging = FirebaseMessaging.DefaultInstance;
        await messaging.SendAsync(messageToSend);
        
        await _dbContext.SaveChangesAsync();
    }
}