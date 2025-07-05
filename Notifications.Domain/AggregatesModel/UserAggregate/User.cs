using Notifications.Domain.AggregatesModel.SeedWork;

namespace Notifications.Domain.AggregatesModel.UserAggregate
{
    public class User : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }

        public User(Guid id, string name, string phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public static User Create(string name, string phoneNumber)
        {
            return new User(Guid.NewGuid(), name, phoneNumber);
        }
    }
}
