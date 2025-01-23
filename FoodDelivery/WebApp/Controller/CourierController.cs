using Domain.DTO_s.CourierDto;
using Domain.DTO_s.ResturantDto;
using Domain.Filters;
using Infrastructure.Response;
using Infrastructure.Service.CourierService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class CourierController(ICourierService service)
{
    [HttpGet]
    public async Task<PaginationResponse<List<GetCourierDto>>> GetResturants([FromQuery]CourierFilter filter) => await service.GetAll(filter);
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetCourierDto>> GetResturant(int id) => await service.GetById(id);
    [HttpPost]
    public async Task<ApiResponse<string>> Add(CreateCourierDto courier) => await service.CreateCourier(courier);
    [HttpPut]
    public async Task<ApiResponse<string>> Update(UpdateCourierDto courier) => await service.UpdateCourier(courier);
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await service.DeleteCourier(id);
    [HttpGet("GetFiveTopCourier")]
    public async Task<ApiResponse<List<GetFiveTopCourier>>> GetTop() => await service.Task8();
}