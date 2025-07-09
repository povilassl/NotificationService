namespace Notifications.Api.Services.Localizations.Content.Models
{
    public class SmsNotificationContent
    {
        public string Body { get; set; }
        private SmsNotificationContent(string body)
        {
            Body = body;
        }

        public SmsNotificationContent Create(string body)
        {
            return new SmsNotificationContent(body);
        }
    }
}
