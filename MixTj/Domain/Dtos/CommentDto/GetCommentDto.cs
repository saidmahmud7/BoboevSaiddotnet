namespace Domain.Dtos.CommentDto;

public class GetCommentDto
{
    public int Id { get; set; }  
    public required string Content { get; set; } 
    public int VideoId { get; set; } 
    public int UserId { get; set; }  
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}