namespace Domain.Entities;

public class Workout
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } 
    public DateTime StartTime { get; set; }
    public TimeSpan Duration { get; set; }
    public int MaxParticipants { get; set; }
    public List<Booking> Bookings { get; set; } 
}