using backend.Models.Base;

namespace backend.Models;

public class Post : BaseEntity
{
    // TODO: see how i can limit title to 50 chars and text to 255
    public string Title { get; set; }
    public string Text { get; set; }
    
    // TODO: img/video here
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    
    public User User { get; set; }
    public Guid UserId { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Saved>? Saves { get; set; }
}