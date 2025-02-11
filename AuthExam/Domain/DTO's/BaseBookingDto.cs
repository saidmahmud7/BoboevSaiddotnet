using Domain.Entities;

namespace Domain.DTO_s;

public class BaseBookingDto
{
    public int UserId { get; set; }
    public int WorkoutId { get; set; }
    public string Status { get; set; }
}

public class GetBookingDto : BaseBookingDto
{
    public int Id { get; set; }
}

public class CreateBookingDto : BaseBookingDto
{
    
}

public class UpdateBookingDto : BaseBookingDto
{
    public int Id { get; set; }
}

public class DeleteBookingDto : BaseBookingDto
{
    public int Id { get; set; }
}