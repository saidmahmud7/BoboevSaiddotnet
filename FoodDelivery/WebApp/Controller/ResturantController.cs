using Domain.DTO_s.ResturantDto;
using Infrastructure.Response;
using Infrastructure.Service.ResturantService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;


[ApiController]
[Route("api/[controller]")]
public class ResturantController(IResturantService service) : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    public async Task<ApiResponse<List<GetResturantDto>>> GetResturants() => await service.GetAll();
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetResturantDto>> GetResturant(int id) => await service.GetById(id);
    [HttpPost]
    public async Task<ApiResponse<string>> Add(CreateResturantDto resturant) => await service.CreateResturant(resturant);
    [HttpPut]
    public async Task<ApiResponse<string>> Update(UpdateResturantDto resturant) => await service.UpdateResturant(resturant);
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await service.DeleteResturant(id);
}