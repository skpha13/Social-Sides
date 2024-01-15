namespace backend.Models.DTOs.CommentDTOs;

public class CreateCommentDTO
{
    public string Text { get; set; }
    public Guid PostId { get; set; }
}