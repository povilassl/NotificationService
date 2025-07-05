using Notifications.Api.Interfaces;
using Notifications.Domain.AggregatesModel.UserAggregate;

namespace Notifications.Api.Services
{
    public class TwilioSmsNotificationService 
        //: ISmsNotificationService
    {
        private readonly ILogger< TwilioSmsNotificationService> _logger;
        private readonly IUserRepository _userRepository; 

        public TwilioSmsNotificationService(ILogger<TwilioSmsNotificationService> logger, IUserRepository userRepository)
        {
            _logger = logger;
        }

        //public Task Send(int customerId)
        //{
        //    try
        //    {
        //        var user = _userRepository.FindById(customerId);

        //        var phone = user.PhoneNumber;
        //        if (string.IsNullOrEmpty(phone))
        //        {
        //            throw new MissingRequiredUserDataException($"Missing customer {customerId} phone number, can not send sms.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"An exception occured when trying to send SMS to ");
        //    }
        //}
    }
}
