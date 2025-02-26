using System.ComponentModel.Design;
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository;

public class OrderRepository(DataContext context, ILogger<OrderRepository> logger) : IOrderRepository
{
    public async Task<List<Order>> GetOrders(BaseFilter filter)
    {
        return await context.Orders
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderById(Expression<Func<Order, bool>>? filter = null)
    {
        var query = context.Orders.AsQueryable();
        if (filter != null)
            query = query.Where(filter);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<int> CreateOrder(Order request)
    {
        try
        {
            await context.Orders.AddAsync(request);
            return await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return 0;
        }
    }

    public async Task<int> UpdateOrder(Order request)
    {
        try
        {
            context.Orders.Update(request);
            return await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return 0;
        }
    }

    public async Task<int> DeleteOrder(Order request)
    {
        try
        {
            context.Orders.Remove(request);
            return await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            logger.LogError(e.Message);
            return 0;
        }
    }
}