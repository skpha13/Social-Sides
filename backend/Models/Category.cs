using backend.Models.Base;

namespace backend.Models;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public ICollection<Post> Posts { get; set; }
    public ICollection<UserFollowsCategory> Users { get; set; }
}