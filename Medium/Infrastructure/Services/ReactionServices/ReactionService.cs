using System.Net;
using AutoMapper;
using Domain.DTOs.ReactionDTOs;
using Domain.Entities;
using Infrastructore.Repositories.IRepositories;
using Infrastructure.Response;

namespace Infrastructore.Services.ReactionServices;

public class ReactionService(IReactionRepository repository, IMapper mapper) : IReactionService
{
    public async Task<ApiResponse<string>> CreateReaction(CreateReactionDTO reaction)
    {
       var reactionn = mapper.Map<Reaction>(reaction);
       var res =await repository.Create(reactionn);
       return res
       ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not created")
       : new ApiResponse<string>("Created successfully!");

    }

    public async Task<ApiResponse<string>> DeleteReaction(int id)
    {
        var res = await repository.Delete(id);
        return res
        ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Not deleted")
        : new ApiResponse<string>("Deleted successfully!");

    }

}
