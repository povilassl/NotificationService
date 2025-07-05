using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.AggregatesModel.UserAggregate;

namespace Notifications.Infrastructure.EntityConfigurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> userConfiguration)
        {
            userConfiguration.ToTable("Users", NotificationsContext.DEFAULT_SCHEMA);

            userConfiguration.HasKey(o => o.Id);

            userConfiguration.Ignore(b => b.DomainEvents);
        }
    }
}
