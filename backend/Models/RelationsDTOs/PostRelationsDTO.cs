using backend.Models.DTOs;

namespace backend.Models.RelationsDTOs;

public class PostRelationsDTO
{
    public CategoryDTO Category { get; set; }
    public UserDTO User { get; set; }
    
        // public ICollection<CommentDTO>? Comments { get; set; }
        // public ICollection<SavedDto>? Saves { get; set; }
}