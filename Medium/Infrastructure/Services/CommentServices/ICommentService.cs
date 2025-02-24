using Domain.DTOs.CommentDTOs;
using Infrastructure.Response;

namespace Infrastructore.Services.CommentServices;

public interface ICommentService
{
    Task<ApiResponse<string>> CreateComment(CreateCommentDTO comment);
    Task<ApiResponse<string>> UpdateComment(int id,UpdateCommentDTO comment);
    Task<ApiResponse<string>> DeleteComment(int id);
    Task<ApiResponse<GetCommentDTO>> GetCommentById(int id);
    Task<ApiResponse<List<GetCommentDTO>>> GetComments();
}
