using Domain.Enums;

namespace Domain.DTOs.ReactionDTOs;

public class BaseReactionDTO
{
    public int UserId { get; set; }
    public int ArticleId { get; set; }
    public ReactionType Type { get; set; }
}
