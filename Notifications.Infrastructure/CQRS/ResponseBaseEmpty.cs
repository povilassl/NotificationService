namespace Notifications.Infrastructure.CQRS
{
    public abstract class ResponseBaseEmpty<T> where T : ResponseBaseEmpty<T>, new()
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = "";

        public static T Error(string message)
        {
            return new T
            {
                IsSuccess = false,
                ErrorMessage = message
            };
        }

        public static T Success()
        {
            return new T
            {
                IsSuccess = true,
            };
        }
    }
}

