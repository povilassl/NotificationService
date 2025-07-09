namespace Notifications.Api.Controllers.Users.Requests
{
    public class CreateUserRequest
    {
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public Guid ExternalId { get; set; }
    }
}
