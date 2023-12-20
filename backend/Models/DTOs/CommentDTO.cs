namespace backend.Models.DTOs;

public class CommentDTO
{
    public Guid? UserId { get; set; }
    public Guid? PostId { get; set; }
}