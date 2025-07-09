using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.AggregatesModel.Entities.User;

namespace Notifications.Infrastructure.EntityConfigurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration.ToTable("Users", NotificationsContext.DEFAULT_SCHEMA);

            userConfiguration.HasKey(o => o.Id);

            userConfiguration.Property(p => p.Name).HasMaxLength(64);

            userConfiguration.Property(p => p.PhoneNumber).HasMaxLength(64);

            userConfiguration.Property(p => p.Email).HasMaxLength(256);

            userConfiguration.Property(p => p.ExternalId);
        }
    }
}
