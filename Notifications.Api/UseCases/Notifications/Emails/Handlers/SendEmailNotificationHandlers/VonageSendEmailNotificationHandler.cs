using Mapster;
using MediatR;
using Notifications.Api.Services.Localizations;
using Notifications.Api.Services.Localizations.Content.Models;
using Notifications.Api.Services.Notifications.Send.Email.Vonage;
using Notifications.Api.UseCases.Notifications.Emails.Commands.SendEmailNotificationCommand;
using Notifications.Domain.AggregatesModel.Entities.Notification;
using Notifications.Domain.AggregatesModel.Entities.User;
using Notifications.Infrastructure.Managers.Notifications.Email;
using System.Text.Json;
using DomainNotificationType = Notifications.Domain.AggregatesModel.Entities.Notification.Models.Enums.NotificationType;

namespace Notifications.Api.UseCases.Notifications.Emails.Handlers.SendEmailNotificationHandlers
{
    public class VonageSendEmailNotificationHandler : INotificationHandler<SendEmailNotificationCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly IVonageEmailNotificationService _emailNotificationService;
        private readonly ILocalizationService _localizationService;
        private readonly IEmailNotificationServicesManager _emailNotificationServicesManager;
        private readonly ILogger<VonageSendEmailNotificationHandler> _logger;

        private readonly string ServiceName = "VonageEmailNotificationService";
        private readonly string NotificationType = "Email";

        public VonageSendEmailNotificationHandler(
            IUserRepository userRepository, 
            INotificationRepository notificationRepository,
            IVonageEmailNotificationService emailNotificationService,
            IEmailNotificationServicesManager emailNotificationServicesManager,
            ILocalizationService localizationService,
            ILogger<VonageSendEmailNotificationHandler> logger)
        {
            _userRepository = userRepository;
            _notificationRepository = notificationRepository;
            _emailNotificationService = emailNotificationService;
            _emailNotificationServicesManager = emailNotificationServicesManager;
            _localizationService = localizationService;
            _logger = logger;
        }

        public async Task Handle(SendEmailNotificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!_emailNotificationServicesManager.IsServiceActive(ServiceName))
                {
                    _logger.LogInformation($"{ServiceName} service for {NotificationType} notification type is disabled and is not a failover service");
                    return;
                }

                var user = await _userRepository.GetByExternalIdAsync(request.ExternalUserId);
                if (user is null)
                {
                    _logger.LogError($"No user was found by externalId: {request.ExternalUserId}");
                    return;
                }

                var emailSubject = _localizationService.GetContent(request.SubjectKey, request.Language);
                var emailBody = _localizationService.GetContent(request.ContentKey, request.Language);

                if (string.IsNullOrEmpty(emailSubject) || string.IsNullOrEmpty(emailBody))
                {
                    _logger.LogError($"Email subject or body localization was empty by keys: " +
                        $"{request.SubjectKey}, {request.ContentKey} and language: {request.Language}");
                }

                var success = await _emailNotificationService.Send(user.Email, emailSubject, emailBody);
                if (!success)
                {
                    _emailNotificationServicesManager.ReportServiceStatusChange(ServiceName, false);
                    _logger.LogError("There was an error sending notification");
                }

                var content = EmailNotificationContent.Create(request.SubjectKey, request.ContentKey);

                var notification = Notification.Create(
                    NotificationType.Adapt<DomainNotificationType>(),
                    request.ExternalUserId,
                    ServiceName,
                    JsonSerializer.Serialize(content),
                    request.Language,
                    success,
                    request.ShouldBeResent,
                    request.CreatedAt);

                await _notificationRepository.AddIfDoesNotExistAsync(notification);
                await _notificationRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = JsonSerializer.Serialize(request);
                _logger.LogError(ex, $"An exception occurred sending notification by  {ServiceName}. Request: {message}");
            }
        }
    }
}
