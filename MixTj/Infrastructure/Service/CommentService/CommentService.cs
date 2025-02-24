using System.Net;
using AutoMapper;
using Domain.Dtos.CommentDto;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.CommentService;

public class CommentService(DataContext context, IMapper mapper) : ICommentService
{
    public async Task<PaginationResponse<List<GetCommentDto>>> GetAll(BaseFilter filter)
    {
        IQueryable<Comment> comments = context.Comments;
        int total = await comments.CountAsync();
        var result = await comments.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => mapper.Map<GetCommentDto>(x))
            .ToListAsync();
        return new PaginationResponse<List<GetCommentDto>>(filter.PageSize, filter.PageNumber, total, result);
    }

    public async Task<ApiResponse<GetCommentDto>> GetById(int id)
    {
        var comment = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if (comment == null)
            return new ApiResponse<GetCommentDto>(HttpStatusCode.NotFound, "Comment Not Found");
        var commentDto = mapper.Map<GetCommentDto>(comment);
        return new ApiResponse<GetCommentDto>(commentDto);
    }

    public async Task<ApiResponse<string>> Create(AddCommentDto comment)
    {
        var comments = mapper.Map<Comment>(comment);
        await context.Comments.AddAsync(comments);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Comment created");
    }

    public async Task<ApiResponse<string>> Update(UpdateCommentDto comment)
    {
        var existing = await context.Comments.FirstOrDefaultAsync(x => x.Id == comment.Id);
        if (existing == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Comment Not Found");

        existing.UserId = comment.UserId;
        existing.Content = comment.Content;
        existing.VideoId = comment.VideoId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Comment updated");
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        var existing = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Comment Not Found");
        context.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Comment deleted");
    }
}