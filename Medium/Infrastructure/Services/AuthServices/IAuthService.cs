using Domain.Enums;

namespace auth.Services.AuthServices;

public interface IAuthService
{
     Task<string> Login(string email, string phoneNumber, string userName, string password);
     bool Register(string email, string phoneNumber, string userName, string password);
}