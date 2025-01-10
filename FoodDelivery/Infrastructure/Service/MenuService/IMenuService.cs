using Domain.DTO_s.MenuDto;
using Domain.DTO_s.ResturantDto;
using Infrastructure.Response;

namespace Infrastructure.Service.MenuService;

public interface IMenuService
{
    Task<ApiResponse<List<GetMenuDto>>> GetAll();
    Task<ApiResponse<GetMenuDto>> GetById(int id);
    Task<ApiResponse<string>> CreateMenu(CreateMenuDto menu);
    Task<ApiResponse<string>> UpdateMenu(UpdateMenuDto menu);
    Task<ApiResponse<string>> DeleteMenu(int id);
    Task<ApiResponse<List<GetMenuDto>>> Task2();
    Task<ApiResponse<List<GetAvarageByCategory>>> Task4();
    Task<ApiResponse<GetCategoryWithCountOfFood>> Task10();
}