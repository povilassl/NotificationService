using Microsoft.Extensions.Options;
using Notifications.Infrastructure.AppSettings.NotificationServices;
using Notifications.Infrastructure.Exceptions;
using Notifications.Infrastructure.Managers.Notifications.Base;

namespace Notifications.Infrastructure.Managers.Notifications.Email
{
    public class EmailNotificationServicesManager : NotificationServicesManager, IEmailNotificationServicesManager
    {
        private readonly NotificationServicesSettings _settings;

        public EmailNotificationServicesManager(IOptions<NotificationServicesSettings> options)
        {
            _settings = options.Value;
            RecalculateActiveService();
        }

        public override void ReportServiceStatusChange(string serviceName, bool isActive)
        {
            var service = _settings.EmailNotificationServices.FirstOrDefault(el => el.Name == serviceName);
            if (service == null)
            {
                throw new NotFoundException($"Service by name {serviceName} was not found in EmailNotificationServices list");
            }

            service!.IsActive = isActive;
            RecalculateActiveService();
        }

        public override void RecalculateActiveService()
        {
            var activeService = _settings.EmailNotificationServices
                .Where(e => e.IsEnabled && e.IsActive)
                .OrderBy(e => e.Priority)
                .FirstOrDefault();

            if (activeService != null)
            {
                ActiveService = activeService.Name;
                return;
            }

            var fallbackService = _settings.EmailNotificationServices
                .Where(e => e.IsActive)
                .OrderBy(e => e.Priority)
                .FirstOrDefault();

            if (fallbackService != null)
            {
                ActiveService = fallbackService.Name;
                return;
            }

            ActiveService = DefaultServiceName;
        }
    }
}
