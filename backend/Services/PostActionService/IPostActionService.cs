using backend.Models.DTOs.CommentDTOs;
using backend.Models.DTOs.LikedDTOs;

namespace backend.Services;

public interface IPostActionService
{
    Task LikePost(string userId, Guid postId);
    Task CommentOnPost(string userId, CreateCommentDTO commentDto);
    Task SaveAsync();
}