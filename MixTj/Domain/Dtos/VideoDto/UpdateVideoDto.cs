namespace Domain.Dtos.VideoDto;

public class UpdateVideoDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }
    public int ChannelId { get; set; }
    public int CategoryId { get; set; }
    public int Views { get; set; } = 0;
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
}