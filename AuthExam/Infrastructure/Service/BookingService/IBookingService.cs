using Domain.DTO_s;
using Infrastructure.Response;

namespace Infrastructure.Service.BookingService;

public interface IBookingService
{
    Task<ApiResponse<List<GetBookingDto>>> GetAllBookings();
    Task<ApiResponse<GetBookingDto?>> GetBookingById(int id);
    Task<ApiResponse<string>> CreateBooking(CreateBookingDto booking);
    Task<ApiResponse<string>> UpdateBooking(UpdateBookingDto booking);
    Task<ApiResponse<string>> DeleteBooking(int id);
}