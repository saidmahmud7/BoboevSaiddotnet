using System.Net;

namespace Infrastructure.Response;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public string Message { get; set; }

    public ApiResponse(T? data)
    {
        Data = data;
        StatusCode = 200;
        Message = "OK";
    }

    public ApiResponse(HttpStatusCode statusCode, string message)
    {
        Data = default;
        StatusCode = (int)StatusCode;
        Message = message;
    }

    public ApiResponse()
    {
        
    }
}