using Domain.DTOs.UserDTOs;
using Domain.DTOs.AuthDTOS;
using Infrastructore.Services.UserServices;
using Infrastructure.Response;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[Route("api/user")]
[ApiController]
public class UserController(IUserService servcie) : ControllerBase
{
   [HttpPut]
    public async Task<ApiResponse<string>> Update(UpdateUserDTO User) => await servcie.UpdateUser(User);
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetUserDTO>> GetById(int id) => await servcie.GetUserById(id);
    [HttpGet]
    public async Task<ApiResponse<List<GetUserDTO>>> GetAll() => await servcie.GetUsers();
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await servcie.DeleteUser(id);
}
