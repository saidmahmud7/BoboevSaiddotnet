﻿using Domain.DTO_s.OrderDto;
using Domain.DTO_s.UserDto;
using Domain.Filters;
using Infrastructure.Response;
using Infrastructure.Service.OrderService;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controller;
[ApiController]
[Route("api/[controller]")]
public class OrderController(IOrderService service)
{
    [HttpGet]
    public async Task<PaginationResponse<List<GetOrderDto>>> GetResturants([FromQuery]OrderFilter filter) => await service.GetAll(filter);
    [HttpGet("{id}")]
    public async Task<ApiResponse<GetOrderDto>> GetResturant(int id) => await service.GetById(id);
    [HttpPost]
    public async Task<ApiResponse<string>> Add(CreateOrderDto order) => await service.CreateOrder(order);
    [HttpPut]
    public async Task<ApiResponse<string>> Update(UpdateOrderDto order) => await service.UpdateOrder(order);
    [HttpDelete]
    public async Task<ApiResponse<string>> Delete(int id) => await service.DeleteOrder(id);
}