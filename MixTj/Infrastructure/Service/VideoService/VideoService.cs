using System.Net;
using AutoMapper;
using Domain.Dtos.VideoDto;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.VideoService;

public class VideoService(DataContext context, IMapper mapper) : IVideoService
{
    public async Task<PaginationResponse<List<GetVideoDto>>> GetAll(BaseFilter filter)
    {
        IQueryable<Video> comments = context.Videos;
        int total = await comments.CountAsync();
        var result = await comments.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => mapper.Map<GetVideoDto>(x))
            .ToListAsync();
        return new PaginationResponse<List<GetVideoDto>>(filter.PageSize, filter.PageNumber, total, result);
    }

    public async Task<ApiResponse<GetVideoDto>> GetById(int id)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if (comment == null)
            return new ApiResponse<GetVideoDto>(HttpStatusCode.NotFound, "Video Not Found");
        var commentDto = mapper.Map<GetVideoDto>(comment);
        return new ApiResponse<GetVideoDto>(commentDto);
    }

    public async Task<ApiResponse<string>> Create(AddVideoDto video)
    {
        var videos = mapper.Map<Video>(video);
        await context.Videos.AddAsync(videos);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Video created");    }

    public async Task<ApiResponse<string>> Update(UpdateVideoDto video)
    {
        var existing = await context.Videos.FirstOrDefaultAsync(x => x.Id == video.Id);
        if (existing == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Comment Not Found");

        existing.Title = video.Title;
        existing.Description = video.Description;
        existing.ChannelId = video.ChannelId;
        existing.CategoryId = video.CategoryId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Video updated");    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        var existing = await context.Videos.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Video Not Found");
        context.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Video deleted");
        
    }
}