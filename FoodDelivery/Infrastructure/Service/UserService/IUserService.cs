using Domain.DTO_s.ResturantDto;
using Domain.DTO_s.UserDto;
using Domain.Filters;
using Infrastructure.Response;

namespace Infrastructure.Service.UserService;

public interface IUserService
{
    Task<PaginationResponse<List<GetUserDto>>> GetAll(UserFilter filter);
    Task<ApiResponse<GetUserDto>> GetById(int id);
    Task<ApiResponse<string>> CreateUser(CreateUserDto user);
    Task<ApiResponse<string>> UpdateUser(UpdateUserDto user);
    Task<ApiResponse<string>> DeleteUser(int id);
}