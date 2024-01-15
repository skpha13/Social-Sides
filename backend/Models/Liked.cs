using backend.Models.Base;

namespace backend.Models;

public class Liked : BaseEntity
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    
    public Post Post { get; set; }
    public Guid PostId { get; set; }
}