namespace Notifications.Infrastructure.AppSettings.NotificationServices.Models
{
    public class NotificationService
    {
        public string Name { get; set; } = "";
        public bool IsEnabled { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public int Priority { get; set; } = int.MaxValue;
    }
}
