using AutoMapper;
using Domain.DTO_s.OrderDetailDto;
using Infrastructure.Data;
using Infrastructure.Response;

namespace Infrastructure.Service.OrderDetail;

public class OrderDetail(DataContext context,IMapper mapper) :IOrderDetail
{
    public Task<ApiResponse<List<GetOrderDetailDto>>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<GetOrderDetailDto>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<string>> CreateDetail(CreateOrderDetailDto detail)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<string>> UpdateDetail(UpdateOrderDetailDto detail)
    {
        throw new NotImplementedException();
    }

    public Task<ApiResponse<string>> DeleteDetail(int id)
    {
        throw new NotImplementedException();
    }
}