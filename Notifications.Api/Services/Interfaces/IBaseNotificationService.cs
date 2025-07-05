namespace Notifications.Api.Services.Interfaces
{
    public interface IBaseNotificationService
    {
        Task Send(int customerId);
    }
}
