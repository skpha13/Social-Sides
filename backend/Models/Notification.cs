using backend.Models.Base;

namespace backend.Models;

public class Notification : BaseEntity
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    
    public NotificationType NotificationType { get; set; }
    public Guid NotificationTypeId { get; set; }
}