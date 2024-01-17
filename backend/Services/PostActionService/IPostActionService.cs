using backend.Models.DTOs.CommentDTOs;
using backend.Models.DTOs.LikedDTOs;

namespace backend.Services;

public interface IPostActionService
{
    Task LikePost(string userId, Guid postId);
    Task UnlikePost(Guid userId, Guid postId);
    Task CommentOnPost(string userId, CreateCommentDTO commentDto);
    Task DeleteComment(Guid userId, Guid commentId);
    Task SaveAsync();
}