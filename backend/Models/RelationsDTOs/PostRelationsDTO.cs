namespace backend.Models.RelationsDTOs;

public class PostRelationsDTO
{
    public Category Category { get; set; }
    public User User { get; set; }
    
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Saved>? Saves { get; set; }
}