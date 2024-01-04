using backend.Models.DTOs.LikedDTOs;

namespace backend.Services;

public interface IPostActionService
{
    Task LikePost(string userId, Guid postId);
}