namespace backend.Models.DTOs;

public class PostIncludesDTO
{
    public Guid Id { get; set; }
    public String Title { get; set; }
    public String Text { get; set; }
    
    public UserDTO User { get; set; }
    public CategoryDTO Category { get; set; }
}