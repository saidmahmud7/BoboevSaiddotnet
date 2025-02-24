using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public int UserId { get; set; }
    public int ArticleId { get; set; }
    [ForeignKey("UserId")]
    public User User { get; set; }
    [ForeignKey("ArticleId")]
    public Article Article { get; set; }
}