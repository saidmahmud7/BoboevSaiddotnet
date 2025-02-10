using Domain.DTO_s;
using Infrastructure.Response;
using Infrastructure.Service.BookingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controller;


[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Client")]
public class BookingController(IBookingService service) : ControllerBase
{
    [HttpPut]
    public async Task<ApiResponse<string>> UpdateBooking(UpdateBookingDto booking) => await service.UpdateBooking(booking);
    
    [HttpPost]
    public async Task<ApiResponse<string>> CreateBooking(CreateBookingDto booking) => await service.CreateBooking(booking);

    [HttpDelete("{id}")]
    public async Task<ApiResponse<string>> DeleteBooking(int id) => await service.DeleteBooking(id);

    [HttpGet("{id}")]
    public async Task<ApiResponse<GetBookingDto?>> GetBookingById(int id) => await service.GetBookingById(id);

    [HttpGet]
    public async Task<ApiResponse<List<GetBookingDto>>> GetAllBookings() => await service.GetAllBookings();
}
