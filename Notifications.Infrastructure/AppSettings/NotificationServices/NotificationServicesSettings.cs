using Notifications.Infrastructure.AppSettings.NotificationServices.Models;

namespace Notifications.Infrastructure.AppSettings.NotificationServices
{
    public class NotificationServicesSettings
    {
        public List<NotificationService> EmailNotificationServices { get; set; } = [];
        public List<NotificationService> SmsNotificationServices { get; set; } = [];
    }
}
