namespace Domain.Entities;

public class Comment
{
    public int Id { get; set; }  
    public required string Content { get; set; } 
    public int VideoId { get; set; } 
    public int UserId { get; set; }  
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } 
    public Video Video { get; set; } 
}