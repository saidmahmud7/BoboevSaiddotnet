using System.Net;
using Domain.Entities;
using Domain.Filter;
using Infrastructure.Repository;
using Infrastructure.Response;

namespace Infrastructure.Service;

public class OrderService(IOrderRepository repository) : IOrderService
{
    public async Task<ApiResponse<List<Order>>> GetAll(BaseFilter filter)
    {
        var allOrders = await repository.GetOrders(new BaseFilter { PageNumber = 1, PageSize = int.MaxValue });
        int totalRecords = allOrders.Count; 

        var orders = allOrders
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToList();

        return new PaginationResponse<List<Order>>(orders, filter.PageNumber, filter.PageSize, totalRecords);
    }

    public async Task<ApiResponse<Order>> GetById(int id)
    {
        var order = await repository.GetOrderById(o => o.Id == id);
        if (order == null)
            return new ApiResponse<Order>(HttpStatusCode.NotFound, "Order not found");
        return new ApiResponse<Order>(order);
    }

    public async Task<ApiResponse<string>> Create(Order order)
    {
        if (order == null)
            return new ApiResponse<string>(HttpStatusCode.BadRequest, "Order cannot be null");

        var result = await repository.CreateOrder(order);
        return result == 1
            ? new ApiResponse<string>("Success")
            : new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed to create order");
    }

    public async Task<ApiResponse<string>> Update(Order order)
    {
        var existingOrder = await repository.GetOrderById(o => o.Id == order.Id);
        if (existingOrder == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Order not found");

        var result = await repository.UpdateOrder(order);
        return result == 1
            ? new ApiResponse<string>("Success")
            : new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed to update order");
    }

    public async Task<ApiResponse<string>> Delete(int id)
    {
        var order = await repository.GetOrderById(o => o.Id == id);
        if (order == null)
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Order not found");

        var result = await repository.DeleteOrder(order);
        return result == 1
            ? new ApiResponse<string>("Success")
            : new ApiResponse<string>(HttpStatusCode.BadRequest, "Failed to delete order");
    }
}