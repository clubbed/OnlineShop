namespace OnlineShop.Application.Response
{
    public class PagedResponse<T> : IResponse
    {
        public PagedResponse(T data, int pageIndex, int totalPages, bool hasPreviousPage, bool hasNextPage)
        {
            Data = data;
            PageIndex = pageIndex;
            TotalPages = totalPages;
            HasPreviousPage = hasPreviousPage;
            HasNextPage = hasNextPage;
        }

        public T Data { get; }

        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public bool HasPreviousPage { get; private set; }
        public bool HasNextPage { get; private set; }
    }
}
