using Microsoft.EntityFrameworkCore;
using Notifications.Domain.AggregatesModel.Entities.Notification;
using Notifications.Domain.AggregatesModel.Entities.User;
using Notifications.Infrastructure.EntityConfigurations;

namespace Notifications.Infrastructure
{
    public class NotificationsContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "notifications";

        public NotificationsContext(DbContextOptions<NotificationsContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationEntityTypeConfiguration());
        }
    }
}
