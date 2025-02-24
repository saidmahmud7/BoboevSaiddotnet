using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Repositories.RepositoryServices;

public class UserRepository(DataContext context) : IUserRepository<User>
{
    public async Task<bool> Delete(int id)
    {
        var exist =await context.Users.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return false;
        context.Users.Remove(exist);
        var res =await context.SaveChangesAsync();
        return res > 0;      
    }

    public async Task<List<User>> GetAll()
    {
        return await context.Users.ToListAsync();
    }

    public async Task<User?> GetById(int id)
    {
        var exist =await context.Users.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return null;
        return exist;
    }

    public async Task<bool> Update(User identity)
    {
        var exist =await context.Users.FirstOrDefaultAsync(x=>x.Id == identity.Id);
        if(exist == null) return false;
        exist.Email = identity.Email;
        exist.PasswordHash = identity.PasswordHash;
        exist.PhoneNumber = identity.PhoneNumber;
        exist.Role = identity.Role;
        exist.UserName = identity.UserName;
        var res =await context.SaveChangesAsync();
        return res > 0;
    }

}
