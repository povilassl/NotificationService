namespace Notifications.Api.UseCases.Users.Common.Models
{
    public class UserDto
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = "";
        public string PhoneNumber { get; private set; } = "";
        public string Email { get; private set; } = "";
        public Guid ExternalId { get; private set; }
    }
}
