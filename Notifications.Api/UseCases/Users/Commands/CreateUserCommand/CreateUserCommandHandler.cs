using Mapster;
using MediatR;
using Notifications.Api.UseCases.Users.Common.Models;
using Notifications.Domain.AggregatesModel.Entities.User;

namespace Notifications.Api.UseCases.Users.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userResponse = await _userRepository.AddAsync(request.Adapt<User>());
                if(userResponse is not null)
                {
                    await _userRepository.SaveChangesAsync();

                    var userDto = userResponse.Adapt<UserDto>();
                    return CreateUserResponse.Success(userDto);
                }

                return CreateUserResponse.Error("There was an error creating new user");
            }
            catch (Exception ex)
            {
                return CreateUserResponse.Error($"An exception occurred trying to create user. Message: {ex.Message}");
            }
        }
    }
}
