using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Service.AuthService;

public class AuthService(DataContext context, IConfiguration configuration) : IAuthService
{
    public async Task<string> Login(string userName, string password)
    {
        User? user = context.Users.FirstOrDefault(x => x.Username == userName && x.PasswordHash == password);
        if (user == null)
            return "Incorrect username or password";

        string key = configuration["JWT:key"]!;
        SigningCredentials credentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>
        {
            new Claim("Id", user.Id.ToString()),
            new Claim("Name", user.Username),
            new Claim("Role", user.Role.ToString())
        };
        
        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: configuration["JWT:Issuer"],
            audience: configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(configuration["JWT:ExpireMinutes"]!)),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public async Task<bool> Register(string userName, string password)
    {
        if (string.IsNullOrEmpty(password)) return false;

        bool conflict =
            context.Users.Any(x => x.Username == userName );

        if (conflict) return false;

        User user = new()
        {
            Username = userName,
            PasswordHash = password
        };
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return true;
    }
}

