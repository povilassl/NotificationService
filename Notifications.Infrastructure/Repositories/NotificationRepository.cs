using Microsoft.EntityFrameworkCore;
using Notifications.Domain.AggregatesModel.Entities.Notification;
using Notifications.Domain.AggregatesModel.Entities.Notification.Models.Enums;

namespace Notifications.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly NotificationsContext _context;

        public NotificationRepository(NotificationsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Notification> AddAsync(Notification notification)
        {
            return (await _context.Notifications.AddAsync(notification)).Entity;
        }

        public async Task<Notification> AddIfDoesNotExistAsync(Notification notification)
        {
            var existing = await _context.Notifications.FirstOrDefaultAsync(n => 
                n.NotificationType == notification.NotificationType &&
                n.ExternalUserId == notification.ExternalUserId && 
                n.Content == notification.Content && 
                n.CreatedAt == notification.CreatedAt);

            if (existing != null)
            {
                return existing;
            }

            var result = await _context.Notifications.AddAsync(notification);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Notification>> GetNotificationsToResendAsync()
        {
            return await _context.Notifications
                .AsNoTracking()
                .Where(el => el.ShouldBeResent)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
