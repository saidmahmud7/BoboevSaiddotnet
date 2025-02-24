namespace Domain.Entities;

public class Subscription
{
    public int Id{ get; set; }
    public int UserId{ get; set; } 
    public int ChannelId { get; set; }  
    public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;

    public User User { get; set; } 
    public Channel Channel { get; set; } 
}