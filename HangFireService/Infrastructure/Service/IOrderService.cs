using Domain.Entities;
using Domain.Filter;
using Infrastructure.Response;

namespace Infrastructure.Service;

public interface IOrderService
{   
    Task<ApiResponse<List<Order>>> GetAll(BaseFilter filter);
    Task<ApiResponse<Order>> GetById(int id);
    Task<ApiResponse<string>> Create(Order order);
    Task<ApiResponse<string>> Update(Order order);
    Task<ApiResponse<string>> Delete(int id);
}