namespace OnlineShop.Application.Response
{
    public class BadResponse : IResponse
    {
        public BadResponse()
        {

        }

        public BadResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
