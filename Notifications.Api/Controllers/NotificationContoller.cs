using Microsoft.AspNetCore.Mvc;

namespace Notifications.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationContoller : ControllerBase
    {
        private readonly ILogger<NotificationContoller> _logger;

        public NotificationContoller(ILogger<NotificationContoller> logger)
        {
            _logger = logger;
        }

        //TODO naming? - now differs
        [HttpPost(Name = "SendSms")]
        public async Task SendSmsNotification(Guid customerId)
        {
            try
            {
                //await _smsNotificationService.Send(customerId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An exception occured while executing {nameof(SendSmsNotification)}.");
            }
        }

        //[HttpPost(Name = "SendEmail")]
        //public Task SendEmail()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}
