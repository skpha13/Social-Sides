namespace backend.Models.DTOs;

public class UpdatePostDTO
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
}