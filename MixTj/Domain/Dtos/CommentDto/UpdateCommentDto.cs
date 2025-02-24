namespace Domain.Dtos.CommentDto;

public class UpdateCommentDto
{
    public int Id { get; set; }  
    public required string Content { get; set; } 
    public int VideoId { get; set; } 
    public int UserId { get; set; }  
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}