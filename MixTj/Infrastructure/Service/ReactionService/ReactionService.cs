using Domain.Dtos.ReactionDto;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Responses;

namespace Infrastructure.Service.ReactionService;

public class ReactionService(DataContext context) : IReactionService
{
    public async Task<PaginationResponse<List<GetReactionDto>>> GetAll(BaseFilter filter)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<GetReactionDto>> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<string>> Create(AddReactionDto reaction)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<string>> Update(UpdateReactionDto reaction)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        throw new NotImplementedException();
    }
}