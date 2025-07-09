using Notifications.Api.UseCases.Users.Common.Models;
using Notifications.Infrastructure.CQRS;

namespace Notifications.Api.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserResponse : ResponseBase<UserDto, CreateUserResponse>
    {
    }
}
