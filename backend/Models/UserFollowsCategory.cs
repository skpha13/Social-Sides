using backend.Models.Base;

namespace backend.Models;

public class UserFollowsCategory : BaseEntity
{
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    
    public User User { get; set; }
    public Guid UserId { get; set; }
}