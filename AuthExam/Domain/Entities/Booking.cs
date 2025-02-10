using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Booking
{
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    public User User { get; set; } 
    [Required]
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } 
    public string Status { get; set; }
}