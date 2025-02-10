using System.Net;
using AutoMapper;
using Domain.DTO_s;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.UserService;

public class Userservice(DataContext context, IMapper mapper) : IUserService
{
    public async Task<ApiResponse<List<GetUsersDto>>> GetAllUsers()
    {
        var users = await context.Users.ToListAsync();
        var userDto = mapper.Map<List<GetUsersDto>>(users);
        return new ApiResponse<List<GetUsersDto>>(userDto);
    }

    public async Task<ApiResponse<GetUsersDto?>> GetUserById(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        var userDto = mapper.Map<GetUsersDto>(user);
        return new ApiResponse<GetUsersDto>(userDto);
    }

    public async Task<ApiResponse<string>> UpdateUser(UpdateUserDto user)
    {
        var existing = await context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
        if (existing == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "User Not Found");
        }

        existing.Username = user.Username;
        existing.Role = user.Role;
        existing.PasswordHash = user.PasswordHash;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "User updated");
    }

    public async Task<ApiResponse<string>> DeleteUser(int id)
    {
        var existing = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "User Not Found");
        }

        context.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "User deleted");
    }
}