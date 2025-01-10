using System.Net;
using AutoMapper;
using Domain.DTO_s.ResturantDto;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.ResturantService;

public class ResturantService(DataContext context, IMapper mapper) : IResturantService
{
    public async Task<ApiResponse<List<GetResturantDto>>> GetAll()
    {
        var resturant = await context.Resturants
            .Include(x=>x.Menus)
            .ToListAsync();
        var resturantDto = mapper.Map<List<GetResturantDto>>(resturant);
        return new ApiResponse<List<GetResturantDto>>(resturantDto);
    }

    public async Task<ApiResponse<GetResturantDto>> GetById(int id)
    {
        var resturant = await context.Resturants.FirstOrDefaultAsync(x => x.Id == id);
        var resturantDto = mapper.Map<GetResturantDto>(resturant);
        return new ApiResponse<GetResturantDto>(resturantDto);
    }

    public async Task<ApiResponse<string>> CreateResturant(CreateResturantDto resturant)
    {
        var resturants = mapper.Map<Restaurant>(resturant);
        context.Resturants.Add(resturants);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Resturant created");
    }

    public async Task<ApiResponse<string>> UpdateResturant(UpdateResturantDto resturant)
    {
        var existingResturant = await context.Resturants.FirstOrDefaultAsync(x => x.Id == resturant.Id);
        if (existingResturant == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Resturant not found");
        }

        existingResturant.Name = resturant.Name;
        existingResturant.Address = resturant.Address;
        existingResturant.Rating = resturant.Rating;
        existingResturant.WorkingHours = resturant.WorkingHours;
        existingResturant.Description = resturant.Description;
        existingResturant.ContactPhone = resturant.ContactPhone;
        existingResturant.IsActive = resturant.IsActive;
        existingResturant.MinOrderAmount = resturant.MinOrderAmount;
        existingResturant.DeliveryPrice = resturant.DeliveryPrice;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Resturant updated");
    }

    public async Task<ApiResponse<string>> DeleteResturant(int id)
    {
        var existingResturant = await context.Resturants.FirstOrDefaultAsync(x => x.Id == id);
        if (existingResturant == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Resturant not found");
        }

        context.Remove(existingResturant);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Resturant deleted");
    }

    public async Task<ApiResponse<List<GetResturantDto>>> Task1()
    {
        var resturants = context.Resturants.ToList();
        var resturantDto = resturants.Where(x=>x.IsActive == true).Select(x => mapper.Map<GetResturantDto>(x)).OrderBy(r=>r.Rating).ToList();
        return new ApiResponse<List<GetResturantDto>>(resturantDto);
    }

    public async Task<ApiResponse<List<GetAnaliticsResturantTop>>> Task11()
    {
        var lastMonth = DateTime.UtcNow.AddMonths(-1);

        var topRestaurants = await context.Orders
            .Where(o => o.CreatedAt >= lastMonth) 
            .GroupBy(o => o.RestaurantId)
            .Select(group => new
            {
                RestaurantId = group.Key,
                OrderCount = group.Count()
            })
            .OrderByDescending(r => r.OrderCount)
            .Take(10)
            .Join(context.Resturants,
                g => g.RestaurantId,
                r => r.Id,
                (g, r) => new GetAnaliticsResturantTop
                {
                    Id = r.Id,
                    Name = r.Name, 
                })
            .ToListAsync();
        return new ApiResponse<List<GetAnaliticsResturantTop>>(topRestaurants);
    }
}