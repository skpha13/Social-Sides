using System.ComponentModel.DataAnnotations;
using backend.Models.Base;

namespace backend.Models;

public class Category : BaseEntity
{
    [Required(ErrorMessage = "A title is required")]
    [MaxLength(20, ErrorMessage = "Title cannot exceed 20 characters")]
    public string Title { get; set; }
    public ICollection<Post>? Posts { get; set; }
    public ICollection<UserFollowsCategory>? Users { get; set; }
}