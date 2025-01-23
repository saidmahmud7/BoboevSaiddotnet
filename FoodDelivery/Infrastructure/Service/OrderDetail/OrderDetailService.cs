using AutoMapper;
using Domain.DTO_s.OrderDetailDto;
using Domain.Filters;
using Infrastructure.Data;
using Infrastructure.Response;
using Domain.Entities;

namespace Infrastructure.Service.OrderDetail;

public class OrderDetailService(DataContext context,IMapper mapper) :IOrderDetail
{
    public Task<PaginationResponse<List<GetOrderDetailDto>>> GetAll(OrderDetailFilter filter)
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