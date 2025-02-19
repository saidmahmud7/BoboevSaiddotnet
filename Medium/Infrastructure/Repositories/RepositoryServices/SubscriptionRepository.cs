using Domain.Entities;
using Infrastructore.Data;
using Infrastructore.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructore.Repositories.RepositoryServices;

public class SubscriptionRepository(DataContext context) : ISubscriptionRepository
{
    public async Task<bool> Create(Subscription identity)
    {
        await context.Subscriptions.AddAsync(identity);
        var res =await context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> Delete(int id)
    {
        var exist =await context.Subscriptions.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return false;
        context.Subscriptions.Remove(exist);
        var res =await context.SaveChangesAsync();
        return res > 0;      
    }

    public async Task<List<Subscription>> GetAll()
    {
        return await context.Subscriptions.ToListAsync();
    }

    public async Task<Subscription?> GetById(int id)
    {
        var exist =await context.Subscriptions.FirstOrDefaultAsync(x=>x.Id == id);
        if(exist == null) return null;
        return exist;
    }

    public async Task<bool> Update(Subscription identity)
    {
        var exist =await context.Subscriptions.FirstOrDefaultAsync(x=>x.Id == identity.Id);
        if(exist == null) return false;
        exist.ExpiryDate = identity.ExpiryDate;
        exist.UserId = identity.UserId;
        var res =await context.SaveChangesAsync();
        return res > 0;
    }

}
