using Domain.Dtos.ChannelDto;
using Domain.Dtos.CommentDto;
using Domain.Filter;
using Infrastructure.Responses;

namespace Infrastructure.Service.CommentService;

public interface ICommentService
{
    Task<PaginationResponse<List<GetCommentDto>>> GetAll(BaseFilter filter);
    Task<ApiResponse<GetCommentDto>> GetById(int id );
    Task<ApiResponse<string>> Create(AddCommentDto comment);
    Task<ApiResponse<string>> Update(UpdateCommentDto comment);
    Task<ApiResponse<string>> Delete(int id); 
}