using System.Net;
using System.Runtime.Intrinsics.X86;
using AutoMapper;
using Domain.DTO_s.CourierDto;
using Domain.DTO_s.MenuDto;
using Domain.DTO_s.OrderDto;
using Domain.Entities;
using Domain.Filters;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.OrderService;

public class OrderService(DataContext context, IMapper mapper) : IOrderService
{
    public async Task<PaginationResponse<List<GetOrderDto>>> GetAll(OrderFilter filter)
    {
        IQueryable<Order> orders = context.Orders;
        if (filter.OrderStatus.HasValue)
            orders = orders.Where(x => x.OrderStatus == filter.OrderStatus);
        if (filter.TotalAmount.HasValue)
            orders = orders.Where(x => x.TotalAmount == filter.TotalAmount);
        if (!string.IsNullOrEmpty(filter.DeliveryAddress))
            orders = orders.Where(x => x.DeliveryAddress.ToLower().Contains(filter.DeliveryAddress.ToLower()));
        int total = await orders.CountAsync();
        var result = await orders
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x=> mapper.Map<GetOrderDto>(x))
            .ToListAsync();
        return new PaginationResponse<List<GetOrderDto>>(filter.PageSize, filter.PageNumber, total, result);
    }

    public async Task<ApiResponse<GetOrderDto>> GetById(int id)
    {
        var order = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        var orderDto = mapper.Map<GetOrderDto>(order);
        return new ApiResponse<GetOrderDto>(orderDto);
    }

    public async Task<ApiResponse<string>> CreateOrder(CreateOrderDto order)
    {
        var orders = mapper.Map<Order>(order);
        context.Orders.Add(orders);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Order created");
    }

    public async Task<ApiResponse<string>> UpdateOrder(UpdateOrderDto order)
    {
        var existingOrder = await context.Orders.FirstOrDefaultAsync(x => x.Id == order.Id);
        if (existingOrder == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Order not found");
        }

        existingOrder.Id = order.Id;
        existingOrder.OrderStatus = order.OrderStatus;
        existingOrder.CreatedAt = order.CreatedAt;
        existingOrder.DeliveredAt = order.DeliveredAt;
        existingOrder.TotalAmount = order.TotalAmount;
        existingOrder.DeliveryAddress = order.DeliveryAddress;
        existingOrder.PaymentMethod = order.PaymentMethod;
        existingOrder.PaymentStatus = order.PaymentStatus;
        existingOrder.CourierId = order.CourierId;
        existingOrder.RestaurantId = order.RestaurantId;
        existingOrder.UserId = order.UserId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Order updated");
    }

    public async Task<ApiResponse<string>> DeleteOrder(int id)
    {
        var existingOrder = await context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        if (existingOrder == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Order not found");
        }

        context.Orders.Remove(existingOrder);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Order deleted");
    }

    public async Task<ApiResponse<List<GetCourierWithOrders>>> Task6()
    {
        var res = await context.Orders.Join(context.Couriers, o => o.CourierId, c => c.Id, (o, c) => new { o, c })
            .Where(g=>g.o.CourierId == g.c.Id)
            .ToListAsync() ;
        var r = mapper.Map<List<GetCourierWithOrders>>(res);
        return new ApiResponse<List<GetCourierWithOrders>>(r); 
    }

    public async Task<ApiResponse<List<GetTotalAmountToday>>> Task7()
    {
        var result = context.Orders.Where(d => d.CreatedAt.Date == DateTime.UtcNow.Date)
            .GroupBy(f => f.CreatedAt)
            .Select(g => new GetTotalAmountToday()
            {
                Date = g.Key,
                Total = g.Sum(v => v.TotalAmount)
            }).ToListAsync();
        var res = mapper.Map<List<GetTotalAmountToday>>(result);
        return new ApiResponse<List<GetTotalAmountToday>>(res);
    }

    public async Task<ApiResponse<List<GetExepensiveOrders>>> Task9()
    {
        var orders = context.Orders
            .Where(x => x.TotalAmount > context.Orders.Average(g => g.TotalAmount))
            .ToListAsync();
        var res = mapper.Map<List<GetExepensiveOrders>>(orders);
        return new ApiResponse<List<GetExepensiveOrders>>(res);
    }

    public async Task<ApiResponse<List<GetCountStatus>>> Task3()
    {
        var order = await context.Orders.ToListAsync();
        var res =  order.GroupBy(x => x.OrderStatus)
            .Select(x => new GetCountStatus()
            {
                Status = x.Key.ToString(),
                Count = x.Count()
            }).ToList();
        return new ApiResponse<List<GetCountStatus>>(res);
    }

   
}