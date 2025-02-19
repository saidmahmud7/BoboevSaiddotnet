using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Reaction
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ArticleId { get; set; }
    public ReactionType Type { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    [ForeignKey("ArticleId")]
    public Article Article { get; set; }
}