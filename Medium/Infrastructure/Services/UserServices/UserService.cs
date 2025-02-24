using System.Net;
using AutoMapper;
using Domain.DTOs.UserDTOs;
using Domain.Entities;
using Infrastructore.Repositories.IRepositories;
using Infrastructure.Response;

namespace Infrastructore.Services.UserServices;

public class UserService(IUserRepository<User> repository,IMapper mapper) : IUserService
{
    public async Task<ApiResponse<string>> DeleteUser(int id)
    {
      var res=await repository.Delete(id);  
      return res
      ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Cannot delete user")
      : new ApiResponse<string>("Created successfully!");
    }

    public async Task<ApiResponse<GetUserDTO>> GetUserById(int id)
    {
        var res =await repository.GetById(id);
        var user = mapper.Map<GetUserDTO>(res);
        if(res == null) return new ApiResponse<GetUserDTO>(null);
        return new ApiResponse<GetUserDTO>(user);
    }

    public async Task<ApiResponse<List<GetUserDTO>>> GetUsers()
    {
        var users = mapper.Map<List<GetUserDTO>>(await repository.GetAll());
        return new ApiResponse<List<GetUserDTO>>(users);
    }

    public async Task<ApiResponse<string>> UpdateUser(UpdateUserDTO user)
    {
       var userr = mapper.Map<User>(user);
       var res =await repository.Update(userr);
       return res
       ? new ApiResponse<string>(HttpStatusCode.InternalServerError,"Cannot update user!")
       : new ApiResponse<string>("Updated successfully");
    }

}
