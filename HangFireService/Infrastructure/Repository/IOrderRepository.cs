using System.Linq.Expressions;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Response;

namespace Infrastructure.Repository;

public interface IOrderRepository
{
    Task<List<Order>> GetOrders(BaseFilter filter);
    Task<Order> GetOrderById(Expression<Func<Order, bool>>? filter = null);
    Task<int> CreateOrder(Order request);
    Task<int> UpdateOrder(Order request);
    Task<int> DeleteOrder(Order request);
}