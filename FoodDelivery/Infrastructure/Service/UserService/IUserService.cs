using Domain.DTO_s.ResturantDto;
using Domain.DTO_s.UserDto;
using Infrastructure.Response;

namespace Infrastructure.Service.UserService;

public interface IUserService
{
    Task<ApiResponse<List<GetUserDto>>> GetAll();
    Task<ApiResponse<GetUserDto>> GetById(int id);
    Task<ApiResponse<string>> CreateUser(CreateUserDto user);
    Task<ApiResponse<string>> UpdateUser(UpdateUserDto user);
    Task<ApiResponse<string>> DeleteUser(int id);
}