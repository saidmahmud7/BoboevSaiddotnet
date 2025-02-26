// using System.Net;
// using AutoMapper;
// using Domain.Dtos.SubscriptionDto;
// using Domain.Dtos.VideoDto;
// using Domain.Entities;
// using Domain.Filter;
// using Infrastructure.Data;
// using Infrastructure.Responses;
// using Microsoft.EntityFrameworkCore;
//
// namespace Infrastructure.Service.SubscriptionService;
//
// public class SubscriptionService(DataContext context, IMapper mapper) : ISubscriptionService
// {
//     public async Task<PaginationResponse<List<GetSubscriptionDto>>> GetAll(BaseFilter filter)
//     {
//         IQueryable<Subscription> subscriptions = context.Subscriptions;
//         int total = await subscriptions.CountAsync();
//         var result = await subscriptions.Skip((filter.PageNumber - 1) * filter.PageSize)
//             .Take(filter.PageSize)
//             .Select(x => mapper.Map<GetSubscriptionDto>(x))
//             .ToListAsync();
//         return new PaginationResponse<List<GetSubscriptionDto>>(filter.PageSize, filter.PageNumber, total, result);
//     }
//
//     public async Task<ApiResponse<GetSubscriptionDto>> GetById(int id)
//     {
//         var subscription = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
//         if (subscription == null)
//             return new ApiResponse<GetSubscriptionDto>(HttpStatusCode.NotFound, "Subscription Not Found");
//         var subscriptionDto = mapper.Map<GetSubscriptionDto>(subscription);
//         return new ApiResponse<GetSubscriptionDto>(subscriptionDto);
//     }
//
//     public async Task<ApiResponse<string>> Create(AddSubscriptionDto subscription)
//     {
//         var subscriptions = mapper.Map<Video>(subscription);
//         await context.Videos.AddAsync(subscriptions);
//         var res = await context.SaveChangesAsync();
//         return res == 0
//             ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
//             : new ApiResponse<string>(HttpStatusCode.OK, "Subscription created");    }
//
//     public async Task<ApiResponse<string>> Update(UpdateSubscriptionDto subscription)
//     {
//         var existing = await context.Subscriptions.FirstOrDefaultAsync(x => x.Id == subscription.Id);
//         if (existing == null)
//             return new ApiResponse<string>(HttpStatusCode.NotFound, "Subscription Not Found");
//
//         existing.UserId = subscription.UserId;
//         existing.ChannelId = subscription.ChannelId;
//         var res = await context.SaveChangesAsync();
//         return res == 0
//             ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
//             : new ApiResponse<string>(HttpStatusCode.OK, "Subscription updated");    }
//
//     public async Task<ApiResponse<string>> Delete(int id)
//     {
//         var existing = await context.Subscriptions.FirstOrDefaultAsync(x => x.Id == id);
//         if (existing == null)
//             return new ApiResponse<string>(HttpStatusCode.NotFound, "Subscription Not Found");
//         context.Remove(existing);
//         var res = await context.SaveChangesAsync();
//         return res == 0
//             ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
//             : new ApiResponse<string>(HttpStatusCode.OK, "Subscription deleted");    }
// }