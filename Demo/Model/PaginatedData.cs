namespace Demo.Model;

public class PaginatedData<T>
{
    public PaginatedData(List<T> items, int pageIndex, int totalCount, int pageSize)
    {
        Items = items;
        PageIndex = pageIndex;
        TotalCount = totalCount;
        PageSize = pageSize;

        TotalPages = TotalCount / pageSize;

        if (TotalCount % pageSize > 0)
            TotalPages++;
    }

    public List<T> Items { get; }
    public int PageIndex { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }
    public int PageSize { get; }
}