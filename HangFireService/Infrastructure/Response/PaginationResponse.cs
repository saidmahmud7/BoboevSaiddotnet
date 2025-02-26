using System.Net;
using Domain.Entities;

namespace Infrastructure.Response;

public class PaginationResponse<T> : ApiResponse<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }

    public PaginationResponse(T data, int totalRecords, int pageNumber, int pageSize) : base(data)
    {
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        PageNumber = pageNumber;
        PageSize = pageSize;
    }

    public PaginationResponse(HttpStatusCode code, string error) : base(code, error)
    {
    }

    public PaginationResponse()
    {
    }

    public PaginationResponse(T data, int filterPageNumber, int filterPageSize)
    {
        Data = data;
        PageNumber = filterPageNumber;
        PageSize = filterPageSize;
    }
}