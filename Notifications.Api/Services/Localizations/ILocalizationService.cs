namespace Notifications.Api.Services.Localizations
{
    public interface ILocalizationService
    {
        public string GetContent(string key, string language);
    }
}
