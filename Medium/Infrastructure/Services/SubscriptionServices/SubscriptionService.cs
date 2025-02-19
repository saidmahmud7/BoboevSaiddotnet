using System.Net;
using AutoMapper;
using Domain.DTOs.SubscriptionDTOs;
using Domain.Entities;
using Infrastructore.Repositories.IRepositories;
using Infrastructure.Response;

namespace Infrastructore.Services.SubscriptionServices;

public class SubscriptionService(ISubscriptionRepository repository, IMapper mapper) : ISubscriptionService
{
    
    public async Task<ApiResponse<string>> CreateSubscription(CreateSubscriptionDTO subscription)
    {
        var subscriptionn = mapper.Map<Subscription>(subscription);
        var res =await repository.Create(subscriptionn);
        return res
        ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not created!")
        : new ApiResponse<string>("Created successfully!");
    }

    public async Task<ApiResponse<string>> DeleteSubscription(int id)
    {
        var res = await repository.Delete(id);
        return res
        ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not deleted!")
        : new ApiResponse<string>("Deleted successfully!");
    }

    public async Task<ApiResponse<GetSubscriptionDTO>> GetSubscriptionById(int id)
    {
       var Subscriptiont =await repository.GetById(id);
       if(Subscriptiont == null) return new ApiResponse<GetSubscriptionDTO>(HttpStatusCode.NotFound,"Not found");
       var Subscription = mapper.Map<GetSubscriptionDTO>(Subscriptiont);
       return new ApiResponse<GetSubscriptionDTO>(Subscription);
    }

    public async Task<ApiResponse<List<GetSubscriptionDTO>>> GetSubscriptions()
    {
       var Subscriptions =mapper.Map<List<GetSubscriptionDTO>>(await repository.GetAll());
       return new ApiResponse<List<GetSubscriptionDTO>>(Subscriptions);
       
    }
}
