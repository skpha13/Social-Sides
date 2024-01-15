using AutoMapper;
using backend.Data;
using backend.Models;
using backend.Models.DTOs.CommentDTOs;
using backend.Repositories.CommentRepository;
using backend.Repositories.LikeRepository;
using backend.Repositories.PostRepository;
using FirebaseAdmin.Messaging;

namespace backend.Services.PostActionService;

public class PostActionService : IPostActionService
{
    private readonly DatabaseContext _dbContext;
    private readonly IPostRepository _postRepository;
    private readonly ILikeRepository _likeRepository;
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public PostActionService(DatabaseContext dbContext,
                            IPostRepository postRepository,
                            ILikeRepository likeRepository,
                            ICommentRepository commentRepository,
                            IMapper mapper)
    {
        _dbContext = dbContext;
        _postRepository = postRepository;
        _likeRepository = likeRepository;
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task LikePost(string userId, Guid postId)
    {
        Post? post = await _postRepository.GetByIdAsync(postId);

        if (post == null)
        {
            throw new Exception("Post not found");
        }

        post.TotalLikes += 1;

        await _likeRepository.CreateAsync(new Liked()
        {
            UserId = new Guid(userId),
            PostId = postId,
            DateCreated = DateTime.Now,
            LastModified = DateTime.Now,
        });
        
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
        await SaveAsync();
    }

    public async Task CommentOnPost(string userId, CreateCommentDTO commentDto)
    {
        Post? post = await _postRepository.GetByIdAsync(commentDto.PostId);

        if (post == null)
        {
            throw new Exception("Post not found");
        }
        
        Comment comment = _mapper.Map<Comment>(commentDto);
        comment.UserId = new Guid(userId);
        
        var messageToSend = new Message()
        {
            Notification = new Notification()
            {
                Title = "Social-Sides",
                Body = $"{post.User.UserName} commented on your post!"
            },
            Token = post.User.DeviceToken
        };

        var messaging = FirebaseMessaging.DefaultInstance;
        await messaging.SendAsync(messageToSend);
        
        await _commentRepository.CreateAsync(comment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}