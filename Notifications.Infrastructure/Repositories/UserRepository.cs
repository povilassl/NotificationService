using Notifications.Domain.AggregatesModel.SeedWork;
using Notifications.Domain.AggregatesModel.UserAggregate;
using System.Data.Entity;

namespace Notifications.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NotificationsContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        IUnitOfWork IRepository<User>.UnitOfWork => throw new NotImplementedException();

        public UserRepository(NotificationsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public User Add(User buyer)
        {
            return _context.Users.Add(buyer).Entity;
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
