namespace Domain.Dtos.SubscriptionDto;

public class AddSubscriptionDto
{
    public int UserId{ get; set; } 
    public int ChannelId { get; set; }  
    public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;
}