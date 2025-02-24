using Domain.Dtos.SubscriptionDto;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Responses;

namespace Infrastructure.Service.SubscriptionService;

public class SubscriptionService(DataContext context) : ISubscriptionService
{
    public async Task<PaginationResponse<List<GetSubscriptionDto>>> GetAll(BaseFilter filter)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<GetSubscriptionDto>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<string>> Create(AddSubscriptionDto subscription)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<string>> Update(UpdateSubscriptionDto subscription)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        throw new NotImplementedException();
    }
}