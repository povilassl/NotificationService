namespace Notifications.Api.Controllers.Notifications.Request
{
    public class SendEmailNotificationRequest
    {
        public Guid ExternalUserId { get; set; }
        public string SubjectKey { get; set; } = "";
        public string ContentKey { get; set; } = "";
        public string Language { get; set; } = "";
        public bool ShouldBeResent { get; set; }
    }
}
