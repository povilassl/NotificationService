namespace Notifications.Infrastructure.Managers.Notifications.Base
{
    public abstract class NotificationServicesManager
    {
        protected const string DefaultServiceName = "DefaultService";
        protected string ActiveService { get; set; } = "";

        public abstract void ReportServiceStatusChange(string serviceName, bool isActive);

        public bool IsServiceActive(string serviceName)
        {
            return ActiveService == serviceName;
        }

        public bool IsAnyServiceActive()
        {
            RecalculateActiveService();
            return !string.IsNullOrEmpty(ActiveService);
        }

        public abstract void RecalculateActiveService();
    }
}
