namespace Notifications.Infrastructure.Exceptions
{
    public class MissingRequiredUserDataException : Exception
    {
        public MissingRequiredUserDataException()
            : base("Missing required user data")
        {
        }

        public MissingRequiredUserDataException(string message)
            : base(message)
        {
        }

        public MissingRequiredUserDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
