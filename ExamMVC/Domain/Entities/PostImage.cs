namespace Domain;

public class PostImage
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = null!;
    public string? Description { get; set; }
    public DateTime UploadDate { get; set; }
    
    public int PostId { get; set; }
    public Post Post { get; set; } = null!;
}
