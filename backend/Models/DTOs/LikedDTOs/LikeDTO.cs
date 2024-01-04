namespace backend.Models.DTOs.LikedDTOs;

public class LikeDTO
{
    public Guid UserId { get; set; }
    public Guid PostId { get; set; }
}