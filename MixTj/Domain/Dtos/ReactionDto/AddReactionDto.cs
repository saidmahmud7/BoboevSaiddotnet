namespace Domain.Dtos.ReactionDto;

public class AddReactionDto
{
    public int UserId { get; set; }  
    public int VideoId { get; set; } 
    public Type Type  { get; set; } 
}