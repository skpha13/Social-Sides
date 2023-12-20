namespace backend.Models.DTOs;

public class PostDTO
{
    public String Title { get; set; }
    public String Text { get; set; }
    
    public Guid UserId { get; set; }
    public UserDTO User { get; set; }
    
    public Guid CategoryId { get; set; }
    public CategoryDTO Category { get; set; }
}