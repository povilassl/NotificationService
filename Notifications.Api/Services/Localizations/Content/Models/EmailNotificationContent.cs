namespace Notifications.Api.Services.Localizations.Content.Models
{
    public class EmailNotificationContent
    {
        public string SubjectKey { get; set; }
        public string ContentKey { get; set; }
        private EmailNotificationContent(string subjectKey, string contentKey)
        {
            SubjectKey = subjectKey;
            ContentKey = contentKey;
        }

        public static EmailNotificationContent Create(string subjectKey, string contentKey)
        {
            return new EmailNotificationContent(subjectKey, contentKey);
        }
    }
}
