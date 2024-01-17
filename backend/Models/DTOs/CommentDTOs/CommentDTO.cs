namespace backend.Models.DTOs.CommentDTOs;

public class CommentDTO
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid? UserId { get; set; }
    public string? UserName { get; set; }
    public DateTime? LastModified { get; set; }
}