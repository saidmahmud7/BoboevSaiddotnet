using Domain.DTO_s.ResturantDto;
using Domain.DTO_s.UserDto;
using Domain.Filters;
using Infrastructure.Response;
using Infrastructure.Service.UserService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService service)
{
    [HttpGet]
    public async Task<PaginationResponse<List<GetUserDto>>> GetResturants([FromQuery]UserFilter filter) => await service.GetAll(filter);
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetUserDto>> GetResturant(int id) => await service.GetById(id);
    [HttpPost]
    public async Task<ApiResponse<string>> Add(CreateUserDto user) => await service.CreateUser(user);
    [HttpPut]
    public async Task<ApiResponse<string>> Update(UpdateUserDto user) => await service.UpdateUser(user);
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await service.DeleteUser(id);
}