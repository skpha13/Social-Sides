using backend.Models.Base;

namespace backend.Models;

public class User : BaseEntity
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ICollection<Post>? Posts { get; set; }
    public ICollection<UserFollowsCategory>? Categories { get; set; }
    public Profile Profile { get; set; }

    public ICollection<Notification>? Notifications { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Saved>? Saves { get; set; }
}