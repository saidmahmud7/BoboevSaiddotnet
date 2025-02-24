using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Enums;
using Infrastructore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace auth.Services.AuthServices;

public class AuthService(DataContext context, IConfiguration configuration,UserManager<IdentityUser> userManager) : IAuthService
{
    public IdentityUser Userr { get; set; }
    public async Task<string> Login(string email, string phoneNumber, string userName, string password)
    {
        User? User = context.Users.FirstOrDefault(x => (x.Email == email || x.PhoneNumber == phoneNumber || x.UserName == userName) && x.PasswordHash == password);
        if (User == null) return "Incorrect username or email or phone number or password";
        
        string key = configuration["JWT:key"]!;
        SigningCredentials credentials =
            new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                SecurityAlgorithms.HmacSha256);

        List<Claim> claims =
        [
            new Claim("Id", User.Id.ToString()),
            new Claim("Name", User.UserName),
            new Claim(ClaimTypes.Email, User.Email),
            new Claim(ClaimTypes.MobilePhone, User.PhoneNumber),
            new Claim(ClaimTypes.Role,User.Role.ToString()),
        ];
        var userRoles = await userManager.GetRolesAsync(Userr);
        claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));


        JwtSecurityToken jwt = new JwtSecurityToken(
            issuer: configuration["JWT:Issuer"],
            audience: configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(double.Parse(configuration["JWT:ExpireMinutes"]!)),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    public bool Register(string email, string phoneNumber, string userName, string password)
    {
        if (string.IsNullOrEmpty(password)) return false;
        if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phoneNumber)) return false;

        bool conflict = context.Users.Any(x => x.Email == userName || x.PhoneNumber == phoneNumber || x.UserName == userName );

        if (conflict) return false;
        User user = new()
        {
            Email = userName,
            PhoneNumber = phoneNumber,
            UserName = userName,
            PasswordHash = password,
        };
        context.Users.Add(user);
        context.SaveChanges();
        return true;
    }
}