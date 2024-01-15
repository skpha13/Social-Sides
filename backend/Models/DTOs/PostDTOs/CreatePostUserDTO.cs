namespace backend.Models.DTOs.PostDTOs;

public class CreatePostUserDTO
{
    public string Text { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
}