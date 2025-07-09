namespace Notifications.Api.Services.Notifications.Send.Email.Common
{
    public interface IEmailNotificationService
    {
        Task<bool> Send(string email, string subject, string content);
    }
}
