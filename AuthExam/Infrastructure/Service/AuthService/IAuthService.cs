using Infrastructure.Response;

namespace Infrastructure.Service.AuthService;

public interface IAuthService
{
    Task<string> Login(string userName, string password);
    Task<bool> Register(string userName, string password);
}