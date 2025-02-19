using Domain.DTOs.ReactionDTOs;
using Infrastructure.Response;

namespace Infrastructore.Services.ReactionServices;

public interface IReactionService
{
    Task<ApiResponse<string>> CreateReaction(CreateReactionDTO reaction);
    Task<ApiResponse<string>> DeleteReaction(int id);

}
