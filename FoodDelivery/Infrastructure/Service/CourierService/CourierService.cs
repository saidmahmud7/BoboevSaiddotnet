using System.Net;
using AutoMapper;
using Domain.DTO_s.CourierDto;
using Domain.DTO_s.UserDto;
using Domain.Entities;
using Domain.Filters;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.CourierService;

public class CourierService(DataContext context, IMapper mapper) : ICourierService
{
    public async Task<PaginationResponse<List<GetCourierDto>>> GetAll(CourierFilter filter)
    {
        IQueryable<Courier> couriers = context.Couriers;
        if (filter.UserId.HasValue)
            couriers = couriers.Where(x => x.UserId == filter.UserId);
        if (filter.Status.HasValue)
            couriers = couriers.Where(x => x.Status == filter.Status);
        if (!string.IsNullOrEmpty(filter.CurrentLocation))
            couriers = couriers.Where(x => x.CurrentLocation.ToLower().Contains(filter.CurrentLocation.ToLower()));
        if (filter.Rating.HasValue)
            couriers = couriers.Where(x => x.Rating == filter.Rating);
        int total = couriers.Count();
        var result = couriers.Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .Select(x => mapper.Map<GetCourierDto>(x))
            .ToList();
        
        return new PaginationResponse<List<GetCourierDto>>(filter.PageSize, filter.PageNumber, total, result);
    }

    public async Task<ApiResponse<GetCourierDto>> GetById(int id)
    {
        var courier = await context.Resturants.FirstOrDefaultAsync(x => x.Id == id);
        var courierDto = mapper.Map<GetCourierDto>(courier);
        return new ApiResponse<GetCourierDto>(courierDto);
    }

    public async Task<ApiResponse<string>> CreateCourier(CreateCourierDto courier)
    {
        var couriers = mapper.Map<Courier>(courier);
        context.Couriers.Add(couriers);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Corurier created");
    }

    public async Task<ApiResponse<string>> UpdateCourier(UpdateCourierDto courier)
    {
        var existingCourier = await context.Couriers.FirstOrDefaultAsync(x => x.Id == courier.Id);
        if (existingCourier == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Corurier not found");
        }

        existingCourier.Id = courier.Id;
        existingCourier.Status = courier.Status;
        existingCourier.CurrentLocation = courier.CurrentLocation;
        existingCourier.Rating = courier.Rating;
        existingCourier.TransportType = courier.TransportType;
        existingCourier.UserId = courier.UserId;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Courier updated");
    }

    public async Task<ApiResponse<string>> DeleteCourier(int id)
    {
        var existingCourier = await context.Couriers.FirstOrDefaultAsync(x => x.Id == id);
        if (existingCourier == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Courier not found");
        }

        context.Remove(existingCourier);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Courier deleted");
    }

    public async Task<ApiResponse<List<GetFiveTopCourier>>> Task8()
    {
        var couriers = await context.Couriers.OrderByDescending(x => x.Rating).Take(5).ToListAsync();
        var res = mapper.Map<List<GetFiveTopCourier>>(couriers);
        return new ApiResponse<List<GetFiveTopCourier>>(res);
    }
}