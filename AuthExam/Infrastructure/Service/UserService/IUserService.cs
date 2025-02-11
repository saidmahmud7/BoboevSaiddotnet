using Domain.DTO_s;
using Domain.Entities;
using Infrastructure.Response;

namespace Infrastructure.Service.UserService;

public interface IUserService
{
    Task<ApiResponse<List<GetUsersDto>>> GetAllUsers();
    Task<ApiResponse<GetUsersDto?>> GetUserById(int id);
    Task<ApiResponse<string>> UpdateUser(UpdateUserDto user);
    Task<ApiResponse<string>> DeleteUser(int id);
}