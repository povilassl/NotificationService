namespace Notifications.Domain.AggregatesModel.Entities.Notification
{
    public interface INotificationRepository
    {
        Task<Notification> AddAsync(Notification notification);
        Task<Notification> AddIfDoesNotExistAsync(Notification notification);
        Task<IEnumerable<Notification>> GetNotificationsToResendAsync();
        Task SaveChangesAsync();
    }
}
