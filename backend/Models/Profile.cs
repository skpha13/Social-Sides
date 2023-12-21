using backend.Models.Base;

namespace backend.Models;

public class Profile : BaseEntity
{
    public String username { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}