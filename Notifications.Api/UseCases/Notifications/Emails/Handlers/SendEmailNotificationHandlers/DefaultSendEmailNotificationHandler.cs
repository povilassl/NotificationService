using Mapster;
using MediatR;
using Notifications.Api.Services.Localizations.Content.Models;
using Notifications.Api.UseCases.Notifications.Common.Models.Enums;
using Notifications.Api.UseCases.Notifications.Emails.Commands.SendEmailNotificationCommand;
using Notifications.Domain.AggregatesModel.Entities.Notification;
using Notifications.Infrastructure.Managers.Notifications.Email;
using System.Text.Json;
using DomainNotificationType = Notifications.Domain.AggregatesModel.Entities.Notification.Models.Enums.NotificationType;

namespace Notifications.Api.UseCases.Notifications.Emails.Handlers.SendEmailNotificationHandlers
{
    public class DefaultSendEmailNotificationHandler : INotificationHandler<SendEmailNotificationCommand>
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IEmailNotificationServicesManager _emailNotificationServicesManager;
        private readonly ILogger<DefaultSendEmailNotificationHandler> _logger;

        private readonly string ServiceName = "DefaultService";
        private readonly NotificationType NotificationType = NotificationType.Email;

        public DefaultSendEmailNotificationHandler(
            INotificationRepository notificationRepository,
            IEmailNotificationServicesManager emailNotificationServicesManager,
            ILogger<DefaultSendEmailNotificationHandler> logger)
        {
            _notificationRepository = notificationRepository;
            _emailNotificationServicesManager = emailNotificationServicesManager;
            _logger = logger;
        }

        //TODO - known bug - if service fails, then it will still be handled by other command handlers
        public async Task Handle(SendEmailNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_emailNotificationServicesManager.IsServiceActive(ServiceName))
                {
                     _logger.LogInformation($"There currently is an active service for sending emails");
                    return;
                }

                var content = EmailNotificationContent.Create(request.SubjectKey, request.ContentKey);

                var notification = Notification.CreateFailed(
                    NotificationType.Adapt<DomainNotificationType>(),
                    request.ExternalUserId,
                    "",
                    JsonSerializer.Serialize(content),
                    request.Language,
                    request.ShouldBeResent,
                    request.CreatedAt);

                await _notificationRepository.AddAsync(notification);
                await _notificationRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"There was an error handling {nameof(SendEmailNotificationCommand)} " +
                    $"with {nameof(DefaultSendEmailNotificationHandler)}");
            }
        }
    }
}
