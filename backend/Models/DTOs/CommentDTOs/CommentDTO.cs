namespace backend.Models.DTOs.CommentDTOs;

public class CommentDTO
{
    public string Text { get; set; }
    public Guid? UserId { get; set; }
    public DateTime? LastModified { get; set; }
}