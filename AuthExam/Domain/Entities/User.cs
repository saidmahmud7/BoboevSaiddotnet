using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    [Required]
    public string Username { get; set; } 
    [Required]
    public string PasswordHash { get; set; } 
    public Role Role { get; set; }
    public List<Workout> Workouts { get; set; }
    public List<Booking> Bookings { get; set; }
}