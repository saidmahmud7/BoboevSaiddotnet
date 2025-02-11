using System.Net;
using AutoMapper;
using Domain.DTO_s;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Response;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Service.BookingService;

public class BookingService(DataContext context,IMapper mapper) : IBookingService
{
    public async Task<ApiResponse<List<GetBookingDto>>> GetAllBookings()
    {
        var bookings = await context.Bookings.ToListAsync();
        var bookingDto = mapper.Map<List<GetBookingDto>>(bookings);
        return new ApiResponse<List<GetBookingDto>>(bookingDto);
    }

    public async Task<ApiResponse<GetBookingDto?>> GetBookingById(int id)
    {
        
        var booking = await context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        var bookingDto = mapper.Map<GetBookingDto>(booking);
        return new ApiResponse<GetBookingDto>(bookingDto);
    }

    public async Task<ApiResponse<string>> CreateBooking(CreateBookingDto booking)
    {
        var bookings = mapper.Map<Booking>(booking);
        await context.Bookings.AddAsync(bookings);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Booking created");
    }

    public async Task<ApiResponse<string>> UpdateBooking(UpdateBookingDto booking)
    {
        var existing = await context.Bookings.FirstOrDefaultAsync(x => x.Id == booking.Id);
        if (existing == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Booking not found");
        }

        existing.Id = booking.Id;
        existing.UserId = booking.UserId;
        existing.WorkoutId = booking.WorkoutId;
        existing.Status = booking.Status;
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Booking updated");
    }

    public async Task<ApiResponse<string>> DeleteBooking(int id)
    {
        var existing = await context.Bookings.FirstOrDefaultAsync(x => x.Id == id);
        if (existing == null)
        {
            return new ApiResponse<string>(HttpStatusCode.NotFound, "Booking not found");
        }
        context.Remove(existing);
        var res = await context.SaveChangesAsync();
        return res == 0
            ? new ApiResponse<string>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new ApiResponse<string>(HttpStatusCode.OK, "Workout deleted");
    }
}