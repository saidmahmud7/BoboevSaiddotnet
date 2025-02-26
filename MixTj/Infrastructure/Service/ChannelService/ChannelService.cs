// using System.Net;
// using AutoMapper;
// using Domain.Dtos.ChannelDto;
// using Domain.Entities;
// using Domain.Filter;
// using Infrastructure.Data;
// using Infrastructure.Repositoriy;
// using Infrastructure.Responses;
// using Microsoft.EntityFrameworkCore;
//
// namespace Infrastructure.Service.ChannelService;
//
// public class ChannelService(ChannelRepository channelRepository) : IChannelService
// {
//     public async Task<PaginationResponse<List<GetChannelDto>>> GetAll(BaseFilter filter)
//     {
//         var categories = await channelRepository.GetAll(filter);
//
//         var totalRecords = categories.Count;
//         var data = categories
//             .Skip((filter.PageNumber - 1) * filter.PageSize)
//             .Take(filter.PageSize)
//             .ToList();
//
//         var result = data.Select(c => new GetChannelDto()
//         {
//             Id = c.Id,
//             UserId = c.UserId,
//             Description = c.Description,
//             SubscribersCount = c.SubscribersCount,
//             Name = c.Name,
//         }).ToList();
//
//         return new PaginationResponse<List<GetChannelDto>>(result, totalRecords, filter.PageNumber, filter.PageSize);
//     }
//
//
//     public async Task<ApiResponse<string>> Create(AddChannelDto request)
//     {
//         var channel = new Channel()
//         {
//             UserId = request.UserId,
//             Description = request.Description,
//             Name = request.Name,
//             SubscribersCount = request.SubscribersCount++
//         };
//
//         var result = await channelRepository.AddChannel(request);
//
//         return result == 1
//             ? new ApiResponse<string>("Success")
//             : new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed");
//     }
//
//     public async Task<ApiResponse<string>> Update(UpdateChannelDto request)
//     {
//         var channels = await channelRepository.GetAll(c => c.Id == request.Id);
//
//         if (channels == null)
//         {
//             return new ApiResponse<string>(HttpStatusCode.NotFound, "Category not found");
//         }
//
//         channels.Name = request.Name;
//
//         var result = await channelRepository.UpdateChannel(channels);
//         return result == 1
//             ? new ApiResponse<string>("Success")
//             : new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed");
//     }
//
//     public async Task<ApiResponse<string>> Delete(int id)
//     {
//         var category = await channelRepository.GetAll(c => c.Id == id);
//         if (category == null)
//         {
//             return new ApiResponse<string>(HttpStatusCode.NotFound, "Category not found");
//         }
//
//         var result = await channelRepository.DeleteChannel(category);
//         return result == 1
//             ? new ApiResponse<string>("Success")
//             : new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed");
//     }
// }