using backend.Models.RelationsDTOs;

namespace backend.Models.DTOs;

public class PostIncludesDTO
{
    public Guid Id { get; set; }
    // public String Title { get; set; }
    public DateTime? DateCreated { get; set; }
    public String Text { get; set; }
    public Int32 TotalLikes { get; set; }
    public bool isLikedByUser { get; set; } = false;
    public PostRelationsDTO Relations { get; set; }
}