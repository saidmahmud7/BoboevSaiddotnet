using Domain.DTO_s.MenuDto;
using Domain.DTO_s.ResturantDto;
using Infrastructure.Response;
using Infrastructure.Service.MenuService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;

[ApiController]
[Route("api/[controller]")]
public class MenuController(IMenuService service) : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    public async Task<ApiResponse<List<GetMenuDto>>> GetMenu() => await service.GetAll();

    [HttpGet("{id}")]
    public async Task<ApiResponse<GetMenuDto>> GetMenu(int id) => await service.GetById(id);

    [HttpPost]
    public async Task<ApiResponse<string>> Add(CreateMenuDto menu) => await service.CreateMenu(menu);

    [HttpPut]
    public async Task<ApiResponse<string>> Update(UpdateMenuDto menu) => await service.UpdateMenu(menu);

    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await service.DeleteMenu(id);
}