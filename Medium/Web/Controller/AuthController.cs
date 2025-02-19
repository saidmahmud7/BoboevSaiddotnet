using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using auth.Services.AuthServices;
using Domain.DTOs;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace auth.Controllers;

[ApiController]
[Route("/api/auth")]
public class AuthController(IAuthService service) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginDTO request)
    {
        string res =await service.Login(request.Email, request.PhoneNumber, request.UserName, request.Password);
        if (res == "Incorrect email or phone number or username or password") return BadRequest(res);
        return Ok(res);
    }

    [HttpPost("register")]
    [Authorize(Roles =nameof(UserRole.Admin))]
    public IActionResult Register([FromBody]RegisterDTO request)
    {
        bool res = service.Register(request.Email, request.PhoneNumber, request.UserName, request.Password);
        return res ? Ok(res) : BadRequest();
    }
}