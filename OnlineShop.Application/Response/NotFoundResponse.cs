namespace OnlineShop.Application.Response
{
    public class NotFoundResponse : IResponse
    {
        public NotFoundResponse()
        {

        }

        public NotFoundResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
