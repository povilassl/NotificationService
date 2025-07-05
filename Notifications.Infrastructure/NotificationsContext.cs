using Microsoft.EntityFrameworkCore;
using Notifications.Domain.AggregatesModel.SeedWork;
using Notifications.Domain.AggregatesModel.UserAggregate;
using Notifications.Infrastructure.EntityConfigurations;

namespace Notifications.Infrastructure
{
    public class NotificationsContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "notifications";

        public NotificationsContext(DbContextOptions<NotificationsContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
        }
    }
}
