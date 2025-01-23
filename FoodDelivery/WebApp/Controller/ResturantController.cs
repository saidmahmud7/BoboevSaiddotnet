using Domain.DTO_s.ResturantDto;
using Domain.Filters;
using Infrastructure.Response;
using Infrastructure.Service.ResturantService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;


[ApiController]
[Route("api/[controller]")]
public class ResturantController(IResturantService service) : Microsoft.AspNetCore.Mvc.Controller
{
    [HttpGet]
    public async Task<PaginationResponse<List<GetResturantDto>>> GetResturants([FromQuery]RestaurantFilter filter) => await service.GetAll(filter);
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetResturantDto>> GetResturant([FromRoute]int id) => await service.GetById(id);
    [HttpPost]
    public async Task<ApiResponse<string>> Add([FromBody]CreateResturantDto resturant) => await service.CreateResturant(resturant);
    [HttpPut]
    public async Task<ApiResponse<string>> Update([FromBody]UpdateResturantDto resturant) => await service.UpdateResturant(resturant);
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await service.DeleteResturant(id);
    [HttpGet("Get")]
    public  Task<ApiResponse<List<GetResturantDto>>> GetTask1() =>  service.Task1();
    [HttpGet("GetAnanlitics")] 
    public async Task<ApiResponse<List<GetAnaliticsResturantTop>>> GetTask11() => await service.Task11();
}
