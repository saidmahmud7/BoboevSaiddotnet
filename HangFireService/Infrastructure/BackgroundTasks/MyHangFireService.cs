using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Infrastructure.BackgroundTasks;

public class MyHangFireService(IServiceScopeFactory serviceScopeFactory, ILogger<MyHangFireService> logger)
{
    public async Task CheckTime()
    {
        logger.LogInformation("Checking time");
        await  using var scope = serviceScopeFactory.CreateAsyncScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
        
        var orders = await dbContext.Orders
            .Where(x => x.DeliveryDeadline() < DateTime.UtcNow && !x.IsDiscountApplied)
            .ToListAsync();
        foreach (var order in orders)
        {
            order.Price = order.Price * 0.8m; 
            order.IsDiscountApplied = true;
            logger.LogInformation("Скидка 20% применена к заказу #" + order.Id);
        }
        await dbContext.SaveChangesAsync();
    }
}   