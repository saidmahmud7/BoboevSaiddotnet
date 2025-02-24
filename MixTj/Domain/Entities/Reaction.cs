using Type = Domain.Enum.Type;

namespace Domain.Entities;

public class Reaction
{
    public int Id { get; set; }  
    public int UserId { get; set; }  
    public int VideoId { get; set; } 
    public Type Type { get; set; } 

    public User User { get; set; } = null!;
    public Video Video { get; set; } = null!;
}