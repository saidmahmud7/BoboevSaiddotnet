using Domain.Dtos.CategoryDto;
using Domain.Dtos.ChannelDto;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Responses;

namespace Infrastructure.Service.ChannelService;

public interface IChannelService
{
    Task<PaginationResponse<List<GetChannelDto>>> GetAll(BaseFilter filter);
    Task<ApiResponse<string>> Create(AddChannelDto request);
    Task<ApiResponse<string>> Update(UpdateChannelDto request);
    Task<ApiResponse<string>> Delete(int id);
}