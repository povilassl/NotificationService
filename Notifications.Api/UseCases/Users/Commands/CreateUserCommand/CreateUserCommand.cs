using MediatR;

namespace Notifications.Api.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<CreateUserResponse>
    {
        public string Name { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        public string Email { get; set; } = "";
        public Guid ExternalId { get; set; }
    }
}
