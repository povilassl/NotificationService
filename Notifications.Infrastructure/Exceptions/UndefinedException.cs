namespace Notifications.Infrastructure.Exceptions
{
    public class UndefinedException : Exception
    {
        public UndefinedException()
            : base("Value was undefined.")
        {
        }

        public UndefinedException(string message)
            : base(message)
        {
        }

        public UndefinedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
