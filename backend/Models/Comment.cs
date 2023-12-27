using System.ComponentModel.DataAnnotations;
using backend.Models.Base;

namespace backend.Models;

public class Comment : BaseEntity
{
    [Required(ErrorMessage = "Text is required for a comment")]
    [MaxLength(128, ErrorMessage = "Text cannot exceed 128 characters")]
    public string Text { get; set; }
    public User? User { get; set; }
    public Guid? UserId { get; set; }
    
    public Post? Post { get; set; }
    public Guid? PostId { get; set; }
}