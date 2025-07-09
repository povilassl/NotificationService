using Notifications.Domain.AggregatesModel.SeedWork;

namespace Notifications.Domain.AggregatesModel.Entities.User
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public Guid ExternalId { get; private set; }

        public User() { } /* For EF */

        private User(Guid id, string name, string phoneNumber, string email, Guid externalId)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
            ExternalId = externalId;
        }

        public static User Create(string name, string phoneNumber, string email, Guid externalId)
        {
            return new User(Guid.NewGuid(), name, phoneNumber, email, externalId);
        }
    }
}
