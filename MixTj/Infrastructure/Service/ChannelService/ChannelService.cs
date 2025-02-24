using System.Net;
using AutoMapper;
using Domain.Dtos.ChannelDto;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.ChannelService;

public class ChannelService(DataContext context, IMapper mapper) : IChannelService
{
    public async Task<PaginationResponse<List<GetChannelDto>>> GetAll(BaseFilter filter)
    {
        IQueryable<Channel> channels = context.Channels;
        int total = await channels.CountAsync();
        var result = await channels.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => mapper.Map<GetChannelDto>(x))
            .ToListAsync();
        return new PaginationResponse<List<GetChannelDto>>(filter.PageSize, filter.PageNumber, total, result);
    }

    public async Task<ApiResponse<GetChannelDto>> GetById(int id)
    {
        var channel = await context.Channels.FirstOrDefaultAsync(x => x.Id == id);
        if (channel == null)
            return new ApiResponse<GetChannelDto>(HttpStatusCode.NotFound, "Channel Not Found");
        var channelDto = mapper.Map<GetChannelDto>(channel);
        return new ApiResponse<GetChannelDto>(channelDto);
    }

    public async Task<ApiResponse<string>> Create(AddChannelDto channel)
    {
        var channels = mapper.Map<Channel>(channel);
        await context.Channels.AddAsync(channels);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Channel created");
    }

    public async Task<ApiResponse<string>> Update(UpdateChannelDto channel)
    {
        var existing = await context.Channels.FirstOrDefaultAsync(x => x.Id == channel.Id);
        if (existing == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Channel Not Found");

        existing.UserId = channel.UserId;
        existing.Name = channel.Name;
        existing.Description = channel.Description;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Channel updated");
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        var existing = await context.Channels.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Channel Not Found");
        context.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Channel deleted");
    }
}