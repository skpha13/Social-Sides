using backend.Models.RelationsDTOs;

namespace backend.Models.DTOs;

public class PostIncludesDTO
{
    public Guid Id { get; set; }
    public String Title { get; set; }
    public String Text { get; set; }

    public PostRelationsDTO Relations { get; set; }
}