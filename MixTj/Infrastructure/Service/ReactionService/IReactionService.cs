using Domain.Dtos.ChannelDto;
using Domain.Dtos.ReactionDto;
using Domain.Filter;
using Infrastructure.Responses;

namespace Infrastructure.Service.ReactionService;

public interface IReactionService
{
    Task<PaginationResponse<List<GetReactionDto>>> GetAll(BaseFilter filter);
    Task<ApiResponse<GetReactionDto>> GetById(int id );
    Task<ApiResponse<string>> Create(AddReactionDto reaction);
    Task<ApiResponse<string>> Update(UpdateReactionDto reaction);
    Task<ApiResponse<string>> Delete(int id);
}