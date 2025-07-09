namespace Notifications.Api.Services.Localizations
{
    public class LocalizationService : ILocalizationService
    {
        public string GetContent(string key, string language)
        {
            return "test content";
        }
    }
}
