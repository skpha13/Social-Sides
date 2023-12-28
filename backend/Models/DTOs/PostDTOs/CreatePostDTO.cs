namespace backend.Models.DTOs;

public class CreatePostDTO
{
    public string Title { get; set; }
    public string Text { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}