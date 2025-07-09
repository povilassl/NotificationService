using MediatR;

namespace Notifications.Api.UseCases.Users.Queries.GetUserQuery
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public Guid Id { get; set; }
    }
}
