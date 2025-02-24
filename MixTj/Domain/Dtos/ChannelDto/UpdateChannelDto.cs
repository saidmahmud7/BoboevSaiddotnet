namespace Domain.Dtos.ChannelDto;

public class UpdateChannelDto
{
    public int Id { get; set; }  
    public int UserId { get; set; }  
    public string Name { get; set; }
    public string? Description { get; set; }
    public int SubscribersCount { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}