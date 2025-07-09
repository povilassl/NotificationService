using Notifications.Domain.AggregatesModel.Entities.Notification.Models.Enums;

namespace Notifications.Domain.AggregatesModel.Entities.Notification
{
    public class Notification
    {
        public NotificationType NotificationType { get; private set; }
        public Guid ExternalUserId { get; private set; }
        public string Provider { get; private set; }
        public string Content { get; private set; }
        public string Language { get; private set; }
        public bool IsSuccessful { get; private set; }
        public bool ShouldBeResent { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }

        public Notification() { /* For EF */}

        private Notification(
            NotificationType notificationType, 
            Guid externaluserId, 
            string provider, 
            string content, 
            string language, 
            bool isSuccessful, 
            bool shouldBeResent, 
            DateTimeOffset createdAt)
        {
            NotificationType = notificationType;
            ExternalUserId = externaluserId;
            Provider = provider;
            Content = content;
            Language = language;
            IsSuccessful = isSuccessful;
            ShouldBeResent = shouldBeResent;
            CreatedAt = createdAt;
        }

        public static Notification CreateFailed(
            NotificationType notificationType,
            Guid externalUserId,
            string provider,
            string content,
            string language,
            bool shouldBeResent,
            DateTimeOffset createdAt)
        {
            return new Notification(
                notificationType, 
                externalUserId, 
                provider, 
                content, 
                language, 
                false, 
                shouldBeResent, 
                createdAt);
        }

        public static Notification Create(
            NotificationType notificationType, 
            Guid externalUserId, 
            string provider, 
            string content, 
            string language, 
            bool isSuccessful, 
            bool shouldBeResent, 
            DateTimeOffset createdAt)
        {
            return new Notification(
                notificationType,
                externalUserId,
                provider,
                content,
                language,
                false,
                shouldBeResent,
                createdAt);
        }
    }
}
