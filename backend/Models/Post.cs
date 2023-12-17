namespace backend.Models;

public class Post
{
    // TODO: see how i can limit title to 50 chars and text to 255
    public string Title, Text;
    // TODO: img/video here
    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
}