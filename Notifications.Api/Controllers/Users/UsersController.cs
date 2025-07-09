using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notifications.Api.Controllers.Users.Requests;
using Notifications.Api.UseCases.Users.Commands.CreateUserCommand;
using Notifications.Api.UseCases.Users.Queries.GetUserQuery;

namespace Notifications.Api.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMediator _mediator;

        public UsersController(ILogger<UsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateUserRequest request)
        {
            try
            {
                var command = new CreateUserCommand
                {
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    Email = request.Email,
                    ExternalId = request.ExternalId
                };

                var result = await _mediator.Send(command);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured while executing {nameof(Create)} method in {nameof(UsersController)}.");
                return BadRequest("An error occured when processing the request.");
            }
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult> Get([FromRoute]Guid userId)
        {
            try
            {
                var query = new GetUserQuery()
                {
                    Id = userId
                };

                var result = await _mediator.Send(query);
                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured while executing {nameof(Get)} method in {nameof(UsersController)}.");
                return BadRequest("An error occured when processing the request.");
            }
        }
    }
}
