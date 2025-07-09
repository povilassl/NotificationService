using MediatR;

namespace Notifications.Api.UseCases.Notifications.Emails.Commands.SendEmailNotificationCommand
{
    public class SendEmailNotificationCommand : INotification
    {
        public Guid ExternalUserId { get; set; }
        public string SubjectKey { get; set; } = "";
        public string ContentKey { get; set; } = "";
        public string Language { get; set; } = "";
        public bool ShouldBeResent { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
