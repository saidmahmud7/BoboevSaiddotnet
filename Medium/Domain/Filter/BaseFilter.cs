namespace Domain.Filter;

public record BaseFilter
{
    protected int PageSize { get; set; }
    public int PageNumber { get; set; }

    public BaseFilter()
    {
        PageNumber = 1;
        PageSize = 10;
    }

    public BaseFilter(int pageNumber, int pageSize)
    {
        PageSize = pageSize <= 0 ? 10 : pageSize;  
        PageNumber = pageNumber <= 0 ? 1 : pageNumber;
    }
}