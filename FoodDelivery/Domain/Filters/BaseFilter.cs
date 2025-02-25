﻿namespace Domain.Filters;

public record BaseFilter
{
    public int PageSize { get; init; }
    public int PageNumber { get; init; }

    protected BaseFilter()
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