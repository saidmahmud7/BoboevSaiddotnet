namespace Domain.Entities;

public class Channel
{
    public int Id { get; set; }  
    public int UserId { get; set; }  
    public string Name { get; set; }
    public string? Description { get; set; }
    public int SubscribersCount { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; }
    public List<Video> Videos { get; set; }
    public List<Subscription> Subscribers { get; set; } 
}