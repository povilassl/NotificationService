namespace Notifications.Infrastructure.Managers.Notifications.Common
{
    public interface INotificationServicesManager
    {
        bool IsServiceActive(string serviceName);
        bool IsAnyServiceActive();
        void ReportServiceStatusChange(string serviceName, bool isActive);
        void RecalculateActiveService();
    }
}
