using Notifications.Api.Services.Localizations.Content.Models;
using Notifications.Api.UseCases.Notifications.Emails.Commands.SendEmailNotificationCommand;
using Notifications.Domain.AggregatesModel.Entities.Notification;
using Notifications.Domain.AggregatesModel.Entities.Notification.Models.Enums;
using Notifications.Infrastructure.Managers.Notifications.Email;
using Notifications.Infrastructure.Managers.Notifications.Sms;
using System.Text.Json;

namespace Notifications.Api.Services.Notifications.Resend.Email
{
    public class ResendFailedEmailNotificationsService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly ILogger<ResendFailedEmailNotificationsService> _logger;
        private readonly IEmailNotificationServicesManager _emailNotificationServicesManager;
        private readonly ISmsNotificationServicesManager _smsNotificationServicesManager;

        public ResendFailedEmailNotificationsService(
            INotificationRepository notificationRepository, 
            ILogger<ResendFailedEmailNotificationsService> logger,
            IEmailNotificationServicesManager emailNotificationServicesManager,
            ISmsNotificationServicesManager smsNotificationServicesManager)
        {
            _notificationRepository = notificationRepository;
            _logger = logger;
            _emailNotificationServicesManager = emailNotificationServicesManager;
            _smsNotificationServicesManager = smsNotificationServicesManager;
        }

        public async Task Send()
        {
            var notifications = await _notificationRepository.GetNotificationsToResendAsync();

            var isEmailServiceActive = _emailNotificationServicesManager.IsAnyServiceActive();
            var isSmsServiceActive = _smsNotificationServicesManager.IsAnyServiceActive();

            if(!isEmailServiceActive && !isSmsServiceActive)
            {
                return;
            }

            foreach(var notification in notifications)
            {
                if (notification.NotificationType == NotificationType.Email && isEmailServiceActive)
                {
                    var content = JsonSerializer.Deserialize<EmailNotificationContent>(notification.Content);

                    if (content == null)
                    {
                        _logger.LogWarning($"Missing content for notification");
                    }
                    else
                    {
                        var command = new SendEmailNotificationCommand()
                        {
                            ExternalUserId = notification.ExternalUserId,
                            SubjectKey = content.SubjectKey,
                            ContentKey = content.ContentKey,
                            Language = notification.Language,
                            ShouldBeResent = notification.ShouldBeResent,
                            CreatedAt = notification.CreatedAt
                        };
                    }
                }
                else if(notification.NotificationType == NotificationType.Sms && isSmsServiceActive)
                {
                    //TODO
                }
                else
                {
                    _logger.LogError($"Notification type is undefined.");
                }
            }
        }
    }
}
