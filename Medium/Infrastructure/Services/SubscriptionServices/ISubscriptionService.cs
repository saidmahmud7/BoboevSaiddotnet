using Domain.DTOs.SubscriptionDTOs;
using Infrastructure.Response;

namespace Infrastructore.Services.SubscriptionServices;

public interface ISubscriptionService
{
    Task<ApiResponse<string>> CreateSubscription(CreateSubscriptionDTO subscription);
    Task<ApiResponse<string>> DeleteSubscription(int id);
    Task<ApiResponse<GetSubscriptionDTO>> GetSubscriptionById(int id);
    Task<ApiResponse<List<GetSubscriptionDTO>>> GetSubscriptions();
}
