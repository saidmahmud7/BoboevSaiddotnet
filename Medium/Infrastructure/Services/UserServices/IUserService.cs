using Domain.DTOs.UserDTOs;
using Domain.Entities;
using Infrastructure.Response;

namespace Infrastructore.Services.UserServices;

public interface IUserService
{
    Task<ApiResponse<string>> UpdateUser(UpdateUserDTO user);
    Task<ApiResponse<string>> DeleteUser(int id);
    Task<ApiResponse<GetUserDTO>> GetUserById(int id);
    Task<ApiResponse<List<GetUserDTO>>> GetUsers();
}
