using Microsoft.EntityFrameworkCore;
using Notifications.Domain.AggregatesModel.Entities.User;

namespace Notifications.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NotificationsContext _context;

        public UserRepository(NotificationsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> AddAsync(User user)
        {
            return (await _context.Users.AddAsync(user)).Entity;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<User?> GetByExternalIdAsync(Guid externalId)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(b => b.ExternalId == externalId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
