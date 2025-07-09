namespace Notifications.Api.Services.Notifications.Send.Email.AmazonSns
{
    public class AmazonSnsEmailNotificationService : IAmazonSnsEmailNotificationService
    {
        public async Task<bool> Send(string email, string subject, string content)
        {
            await Task.Delay(100);

            //if (serviceFails)
            //{
            //    return false;
            //}

            return true;
        }
    }
}
