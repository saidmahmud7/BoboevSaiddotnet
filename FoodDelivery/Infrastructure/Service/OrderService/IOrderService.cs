﻿using Domain.DTO_s.CourierDto;
using Domain.DTO_s.OrderDto;
using Domain.Filters;
using Infrastructure.Response;

namespace Infrastructure.Service.OrderService;

public interface IOrderService
{
    Task<PaginationResponse<List<GetOrderDto>>> GetAll(OrderFilter filter);
    Task<ApiResponse<GetOrderDto>> GetById(int id);
    Task<ApiResponse<string>> CreateOrder(CreateOrderDto order);
    Task<ApiResponse<string>> UpdateOrder(UpdateOrderDto order);
    Task<ApiResponse<string>> DeleteOrder(int id);
    Task<ApiResponse<List<GetCourierWithOrders>>> Task6();
    Task<ApiResponse<List<GetTotalAmountToday>>> Task7();
    Task<ApiResponse<List<GetExepensiveOrders>>> Task9();
}