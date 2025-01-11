using Domain.DTO_s.ResturantDto;
using Domain.Filters;
using Infrastructure.Response;

namespace Infrastructure.Service.ResturantService;

public interface IResturantService
{
    Task<PaginationResponse<List<GetResturantDto>>> GetAll(RestaurantFilter filter);
    Task<ApiResponse<GetResturantDto>> GetById(int id);
    Task<ApiResponse<string>> CreateResturant(CreateResturantDto resturant);
    Task<ApiResponse<string>> UpdateResturant(UpdateResturantDto resturant);
    Task<ApiResponse<string>> DeleteResturant(int id);
    Task<ApiResponse<List<GetResturantDto>>> Task1();
    Task<ApiResponse<List<GetAnaliticsResturantTop>>> Task11();
}