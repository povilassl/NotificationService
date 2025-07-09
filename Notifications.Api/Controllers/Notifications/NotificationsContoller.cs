using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notifications.Api.Controllers.Notifications.Request;
using Notifications.Api.UseCases.Notifications.Emails.Commands.SendEmailNotificationCommand;

namespace Notifications.Api.Controllers.Notifications
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsContoller : ControllerBase
    {
        private readonly ILogger<NotificationsContoller> _logger;
        private readonly IMediator _mediator;

        public NotificationsContoller(ILogger<NotificationsContoller> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("email")]
        public async Task SendEmailNotification([FromBody] SendEmailNotificationRequest request)
        {
            try
            {
                var command = new SendEmailNotificationCommand
                {
                    ExternalUserId = request.ExternalUserId,
                    SubjectKey = request.SubjectKey,
                    ContentKey = request.ContentKey,
                    Language = request.Language,
                    ShouldBeResent = request.ShouldBeResent,
                    CreatedAt = DateTimeOffset.UtcNow
                };

                await _mediator.Publish(command);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured while executing {nameof(SendEmailNotification)} method in {nameof(NotificationsContoller)}.");
            }
        }
    }
}
