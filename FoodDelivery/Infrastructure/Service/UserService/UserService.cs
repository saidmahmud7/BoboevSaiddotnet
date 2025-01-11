using System.Net;
using AutoMapper;
using Domain.DTO_s.UserDto;
using Domain.Entities;
using Domain.Filters;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.UserService;

public class UserService(DataContext context, IMapper mapper) : IUserService
{
    public async Task<PaginationResponse<List<GetUserDto>>> GetAll(UserFilter filter)
    {
        IQueryable<User> users = context.Users;
        if (!string.IsNullOrEmpty(filter.Name)) 
            users = users.Where(x => x.Name.ToLower().Contains(filter.Name.ToLower()));
        if (!string.IsNullOrEmpty(filter.Email))
            users = users.Where(x => x.Email.ToLower().Contains(filter.Email.ToLower()));
        if (!string.IsNullOrEmpty(filter.Phone))
            users = users.Where(x=>x.Phone.ToLower().Contains(filter.Phone.ToLower()));
        if (!string.IsNullOrEmpty(filter.Address))
            users = users.Where(x=>x.Address.ToLower().Contains(filter.Address.ToLower()));
        if (filter.Role.HasValue)
            users = users.Where(x => x.Role == filter.Role);
        if (filter.RegistrationDate is not null)
            users = users.Where(x => x.RegistrationDate == filter.RegistrationDate);
        int total = await users.CountAsync();
        var result = await users
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x=>mapper.Map<GetUserDto>(x))
            .ToListAsync();
        return new PaginationResponse<List<GetUserDto>>(filter.PageSize, filter.PageNumber, total, result);
    }

    public async Task<ApiResponse<GetUserDto>> GetById(int id)
    {
        var user = await context.Resturants.FirstOrDefaultAsync(x => x.Id == id);
        var userDto = mapper.Map<GetUserDto>(user);
        return new ApiResponse<GetUserDto>(userDto);
    }

    public async Task<ApiResponse<string>> CreateUser(CreateUserDto user)
    {
        var users = mapper.Map<User>(user);
        context.Users.Add(users);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "User created");
    }

    public async Task<ApiResponse<string>> UpdateUser(UpdateUserDto user)
    {
        var existingUser = await context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
        if (existingUser == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "User not found");
        }

        existingUser.Id = user.Id;
        existingUser.Name = user.Name;
        existingUser.Phone = user.Phone;
        existingUser.Password = user.Password;
        existingUser.Address = user.Address;
        existingUser.RegistrationDate = user.RegistrationDate;
        existingUser.Role = user.Role;
        existingUser.Email = user.Email;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "User updated");
    }

    public async Task<ApiResponse<string>> DeleteUser(int id)
    {
        var existingUser = await context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (existingUser == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "User not found");
        }

        context.Remove(existingUser);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "User deleted");
    }
}