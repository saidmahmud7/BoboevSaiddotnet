using Domain.Dtos.CategoryDto;
using Domain.Dtos.ChannelDto;
using Domain.Filter;
using Infrastructure.Responses;

namespace Infrastructure.Service.ChannelService;

public interface IChannelService
{
    Task<PaginationResponse<List<GetChannelDto>>> GetAll(BaseFilter filter);
    Task<ApiResponse<GetChannelDto>> GetById(int id );
    Task<ApiResponse<string>> Create(AddChannelDto channel);
    Task<ApiResponse<string>> Update(UpdateChannelDto channel);
    Task<ApiResponse<string>> Delete(int id);
}