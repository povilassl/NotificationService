using Notifications.Domain.AggregatesModel.SeedWork;

namespace Notifications.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> Get(Guid id);
    }
}
