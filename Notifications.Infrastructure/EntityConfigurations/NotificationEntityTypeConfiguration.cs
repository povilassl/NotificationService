using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.AggregatesModel.Entities.Notification;

namespace Notifications.Infrastructure.EntityConfigurations
{
    class NotificationEntityTypeConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> notificationConfiguration)
        {
            notificationConfiguration.ToTable("Notifications", NotificationsContext.DEFAULT_SCHEMA);

            notificationConfiguration.HasKey(o => new { o.NotificationType, o.ExternalUserId, o.Content, o.CreatedAt });

            notificationConfiguration.Property(p => p.NotificationType).HasConversion<string>().HasMaxLength(64);

            notificationConfiguration.Property(p => p.ExternalUserId);

            notificationConfiguration.Property(p => p.Provider).HasMaxLength(256);

            notificationConfiguration.Property(p => p.Content).HasMaxLength(256);

            notificationConfiguration.Property(p => p.Language).HasMaxLength(16);

            notificationConfiguration.Property(p => p.IsSuccessful);

            notificationConfiguration.Property(p => p.ShouldBeResent);

            notificationConfiguration.Property(p => p.CreatedAt);
        }
    }
}
