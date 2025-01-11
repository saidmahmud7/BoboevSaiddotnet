using Domain.DTO_s.MenuDto;
using Domain.DTO_s.ResturantDto;
using Domain.Filters;
using Infrastructure.Response;
using Infrastructure.Service.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class MenuController(IMenuService service) : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    public async Task<PaginationResponse<List<GetMenuDto>>> GetMenu([FromQuery]MenuFilter filter) => await service.GetAll(filter);

    [HttpGet("{id}")]
    public async Task<ApiResponse<GetMenuDto>> GetMenu(int id) => await service.GetById(id);

    [HttpPost]
    public async Task<ApiResponse<string>> Add(CreateMenuDto menu) => await service.CreateMenu(menu);

    [HttpPut]
    public async Task<ApiResponse<string>> Update(UpdateMenuDto menu) => await service.UpdateMenu(menu);

    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await service.DeleteMenu(id);
    [HttpGet("task2")]
    public async Task<ApiResponse<List<GetMenuDto>>> GetTask2() => await service.Task2();
    [HttpGet("GetAvarageByCategory")]
    public async Task<ApiResponse<List<GetAvarageByCategory>>> GetTask4() => await service.Task4();
    [HttpGet("GetCategoryWithCountOfFood")]
    public async Task<ApiResponse<GetCategoryWithCountOfFood>> Task10() => await service.Task10();
}