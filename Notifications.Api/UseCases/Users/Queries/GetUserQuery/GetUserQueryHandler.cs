using Mapster;
using MediatR;
using Notifications.Api.UseCases.Users.Common.Models;
using Notifications.Domain.AggregatesModel.Entities.User;

namespace Notifications.Api.UseCases.Users.Queries.GetUserQuery
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.Id);
                if(user is null)
                {
                    return GetUserResponse.Error($"No user was found by id: {request.Id}");
                }

                var userDto = user.Adapt<UserDto>();
                return GetUserResponse.Success(userDto);
            }
            catch (Exception ex)
            {
                return GetUserResponse.Error($"An exception occurred trying to get user by id: {request.Id}");
            }
        }
    }
}
