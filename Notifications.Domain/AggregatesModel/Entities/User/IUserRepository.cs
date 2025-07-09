namespace Notifications.Domain.AggregatesModel.Entities.User
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByExternalIdAsync(Guid externalId);
        Task<User> AddAsync(User user);
        Task SaveChangesAsync();
    }
}
