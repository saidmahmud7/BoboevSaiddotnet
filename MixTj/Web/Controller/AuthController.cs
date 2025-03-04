using Domain.Dtos.AuthDto;
using Infrastructure.Responses;
using Infrastructure.Seed;
using Infrastructure.Service.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService)
{
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<ApiResponse<string>> Register(RegisterDto request)
    {
        return await authService.Register(request);
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ApiResponse<string>> Login(LoginDto request)
    {
        return await authService.Login(request);
    }
    
    [HttpPost("add-role-to-user")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<ApiResponse<string>> AddRoleToUser(RoleDto request)
    {
        return await authService.AddRoleToUser(request);
    }
    
    [HttpDelete("remove-role-from-user")]
    [Authorize(Roles = Roles.Admin)]
    public async Task<ApiResponse<string>> RemoveRoleFromUser(RoleDto request)
    {
        return await authService.RemoveRoleFromUser(request);
    }
}