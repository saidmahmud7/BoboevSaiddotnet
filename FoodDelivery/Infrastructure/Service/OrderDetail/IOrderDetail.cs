using Domain.DTO_s.MenuDto;
using Domain.DTO_s.OrderDetailDto;
using Infrastructure.Response;

namespace Infrastructure.Service.OrderDetail;

public interface IOrderDetail
{
    Task<ApiResponse<List<GetOrderDetailDto>>> GetAll();
    Task<ApiResponse<GetOrderDetailDto>> GetById(int id);
    Task<ApiResponse<string>> CreateDetail(CreateOrderDetailDto detail);
    Task<ApiResponse<string>> UpdateDetail(UpdateOrderDetailDto detail);
    Task<ApiResponse<string>> DeleteDetail(int id);
}