using backend.Models.Base;

namespace backend.Models;

public class Profile : BaseEntity
{
    public User User { get; set; }
}