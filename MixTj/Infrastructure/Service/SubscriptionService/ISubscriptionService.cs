using Domain.Dtos.ChannelDto;
using Domain.Dtos.SubscriptionDto;
using Domain.Filter;
using Infrastructure.Responses;

namespace Infrastructure.Service.SubscriptionService;

public interface ISubscriptionService
{
    Task<PaginationResponse<List<GetSubscriptionDto>>> GetAll(BaseFilter filter);
    Task<ApiResponse<GetSubscriptionDto>> GetById(int id );
    Task<ApiResponse<string>> Create(AddSubscriptionDto subscription);
    Task<ApiResponse<string>> Update(UpdateSubscriptionDto subscription);
    Task<ApiResponse<string>> Delete(int id);
}