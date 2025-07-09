namespace Notifications.Infrastructure.CQRS
{
    public abstract class ResponseBase<TData, TResponse>
        where TResponse : ResponseBase<TData, TResponse>, new()
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; } = "";
        public TData Data { get; set; }

        protected ResponseBase() { }

        public static TResponse Error(string message)
        {
            return new TResponse
            {
                IsSuccess = false,
                ErrorMessage = message
            };
        }

        public static TResponse Success(TData data)
        {
            return new TResponse
            {
                IsSuccess = true,
                Data = data,
            };
        }
    }
}

