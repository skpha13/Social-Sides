using backend.Models.DTOs;
using backend.Models.DTOs.CommentDTOs;

namespace backend.Models.RelationsDTOs;

public class PostRelationsDTO
{
    public CategoryDTO? Category { get; set; }
    public UserDTO? User { get; set; }
    public List<CommentDTO>? Comments { get; set; }
    
        // public ICollection<SavedDto>? Saves { get; set; }
}