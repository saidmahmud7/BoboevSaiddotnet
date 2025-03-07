﻿using Domain.DTO_s.CourierDto;
using Domain.DTO_s.UserDto;
using Domain.Filters;
using Infrastructure.Response;

namespace Infrastructure.Service.CourierService;

public interface ICourierService
{
    Task<PaginationResponse<List<GetCourierDto>>> GetAll(CourierFilter filter);
    Task<ApiResponse<GetCourierDto>> GetById(int id);
    Task<ApiResponse<string>> CreateCourier(CreateCourierDto courier);
    Task<ApiResponse<string>> UpdateCourier(UpdateCourierDto courier);
    Task<ApiResponse<string>> DeleteCourier(int id);
    Task<ApiResponse<List<GetFiveTopCourier>>> Task8();
}