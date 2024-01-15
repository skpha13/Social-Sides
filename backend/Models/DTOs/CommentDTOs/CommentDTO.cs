namespace backend.Models.DTOs.CommentDTOs;

public class CommentDTO
{
    public string Text { get; set; }
    public string UserName { get; set; }
    public DateTime? LastModified { get; set; }
}