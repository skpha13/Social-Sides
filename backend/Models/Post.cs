using System.ComponentModel.DataAnnotations;
using backend.Models.Base;

namespace backend.Models;

public class Post : BaseEntity
{
    [MaxLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
    public string Text { get; set; }
    public Int32 TotalLikes { get; set; }
    
    // TODO: img/video here with AWS
    public Category? Category { get; set; }
    public Guid? CategoryId { get; set; }
    
    public User User { get; set; }
    public Guid UserId { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Liked>? Likes { get; set; }
}