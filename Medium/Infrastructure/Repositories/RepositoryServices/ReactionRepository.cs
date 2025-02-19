using System.Threading.Tasks;
using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Repositories.RepositoryServices;

public class ReactionRepository(DataContext context) : IReactionRepository
{
    public async Task<bool> Create(Reaction identity)
    {
        await context.Reactions.AddAsync(identity);
        var res =await context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var exist =await context.Reactions.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return false;
        context.Reactions.Remove(exist);
        var res =await context.SaveChangesAsync();
        return res > 0;      
    }

    public async Task<List<Reaction>> GetAll()
    {
        return await context.Reactions.ToListAsync();
    }

    public async Task<Reaction?> GetById(int id)
    {
        var exist =await context.Reactions.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return null;
        return exist;
    }

    public async Task<bool> Update(Reaction identity)
    {
        var exist =await context.Reactions.FirstOrDefaultAsync(x=>x.Id == identity.Id);
        if(exist == null) return false;
        exist.ArticleId = identity.ArticleId;
        exist.Type = identity.Type;
        exist.UserId = identity.UserId;
        var res =await context.SaveChangesAsync();
        return res > 0;
    }

}
