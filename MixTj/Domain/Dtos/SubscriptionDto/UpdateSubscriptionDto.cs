namespace Domain.Dtos.SubscriptionDto;

public class UpdateSubscriptionDto
{
    public int Id{ get; set; }
    public int UserId{ get; set; } 
    public int ChannelId { get; set; }  
    public DateTime SubscribedAt { get; set; } = DateTime.UtcNow;
}