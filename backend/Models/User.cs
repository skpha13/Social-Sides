using Microsoft.AspNetCore.Identity;

namespace backend.Models;

public class User : IdentityUser<Guid>
{
    public string DeviceToken { get; set; }
    public ICollection<Post>? Posts { get; set; }
    public ICollection<UserFollowsCategory>? Categories { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Saved>? Saves { get; set; }
    public ICollection<Liked>? Likes { get; set; }
}