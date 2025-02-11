using Domain.DTO_s;
using Infrastructure.Response;
using Infrastructure.Service.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;


[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Admin")]
public class UserController(IUserService service)
{
    [HttpPut]
    public async Task<ApiResponse<string>> UpdateUser(UpdateUserDto user) => await service.UpdateUser(user);

    [HttpDelete("{id}")]
    public async Task<ApiResponse<string>> DeleteUser(int id) => await service.DeleteUser(id);

    [HttpGet("{id}")]
    public async Task<ApiResponse<GetUsersDto?>> GetUserById(int id) => await service.GetUserById(id);

    [HttpGet]
    public async Task<ApiResponse<List<GetUsersDto>>> GetAllUsers() => await service.GetAllUsers();
}
