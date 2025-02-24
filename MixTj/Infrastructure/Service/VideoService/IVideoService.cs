using Domain.Dtos.ChannelDto;
using Domain.Dtos.VideoDto;
using Domain.Filter;
using Infrastructure.Responses;

namespace Infrastructure.Service.VideoService;

public interface IVideoService
{
    Task<PaginationResponse<List<GetVideoDto>>> GetAll(BaseFilter filter);
    Task<ApiResponse<GetVideoDto>> GetById(int id );
    Task<ApiResponse<string>> Create(AddVideoDto video);
    Task<ApiResponse<string>> Update(UpdateVideoDto video);
    Task<ApiResponse<string>> Delete(int id);
}