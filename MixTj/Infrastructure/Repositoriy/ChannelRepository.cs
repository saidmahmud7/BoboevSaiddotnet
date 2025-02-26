using System.Linq.Expressions;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Service.ChannelService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositoriy;

public class ChannelRepository(DataContext context, ILogger<ChannelRepository> logger) : IChannelRepository
{
    public async Task<List<Channel>> GetAll(BaseFilter filter)
    {
        var query = context.Channels.AsQueryable();


        var categories = await query.ToListAsync();
        return categories;
    }

    public async Task<Channel?> Channel(Expression<Func<Channel, bool>>? filter = null)
    {
        var query = context.Channels.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<int> AddChannel(Channel request)
    {
        try
        {
            await context.Channels.AddAsync(request);
            return await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return 0;
        }
    }

    public async Task<int> UpdateChannel(Channel request)
    {
        try
        {
            context.Channels.Update(request);
            return await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return 0;
        }
    }

    public async Task<int> DeleteChannel(Channel request)
    {
        try
        {
            context.Channels.Remove(request);
            return await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return 0;
        }
    }
}