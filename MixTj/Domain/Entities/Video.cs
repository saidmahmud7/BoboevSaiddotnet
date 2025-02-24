namespace Domain.Entities;

public class Video
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string? Description { get; set; }
    public int ChannelId { get; set; }  
    public int CategoryId { get; set; }  
    public int Views { get; set; } = 0;
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    public Channel Channel { get; set; } 
    public Category Category { get; set; } 
    public List<Comment> Comments { get; set; }
    public List<Reaction> Reactions { get; set; }
}