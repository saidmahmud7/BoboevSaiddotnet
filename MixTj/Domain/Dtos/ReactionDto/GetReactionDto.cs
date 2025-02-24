namespace Domain.Dtos.ReactionDto;

public class GetReactionDto
{
    public int Id { get; set; }  
    public int UserId { get; set; }  
    public int VideoId { get; set; } 
    public Type Type { get; set; } 
}