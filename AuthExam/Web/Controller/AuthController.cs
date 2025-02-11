using Domain.DTO_s;
using Infrastructure.Service.AuthService;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;

[ApiController]
[Route("/api/auth")]
public class AuthController(IAuthService service) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginAccountDto request)
    {
        var res = await service.Login(request.Username, request.PasswordHash);
        if (res == "Incorrect username or password")
        {
            return Unauthorized(new { message = res });
        }
        return Ok(new { token = res });
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterAccountDto request)
    {
        var res = await service.Register(request.Username, request.PasswordHash);
        return res ? Ok(new { message = "User registered successfully" }) : BadRequest(new { message = "Registration failed" });
    }
}