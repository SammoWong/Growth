namespace Growth.Application
{
    public interface IPageableRequest
    {
        int PageIndex { get; set; }

        int PageSize { get; set; }
    }
}
