using Domain.Dtos.AuthDto;
using Infrastructure.Responses;

namespace Infrastructure.Service.AuthServices;

public interface IAuthService
{
    Task<ApiResponse<string>> Register(RegisterDto model);
    Task<ApiResponse<string>> Login(LoginDto login);
    Task<ApiResponse<string>> RemoveRoleFromUser(RoleDto userRole);
    Task<ApiResponse<string>> AddRoleToUser(RoleDto userRole);
}