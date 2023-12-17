using backend.Models.Base;

namespace backend.Models;

public class NotificationType : BaseEntity
{
    public Notification? Notification { get; set; }
}