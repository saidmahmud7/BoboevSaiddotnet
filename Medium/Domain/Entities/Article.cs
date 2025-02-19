using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Article
{
    public int Id { get; set; }
    [Required,MaxLength(50)]
    public string Title { get; set; }
    [Required,MaxLength(50)]
    public string Content { get; set; }
    public bool IsPremium { get; set; }
    public bool IsDraft { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? PublishedAt { get; set; }
    public List<string> Tags { get; set; }
    public int AuthorId { get; set; }
    [ForeignKey("AuthorId")]
    public User Author { get; set; }
    public List<Comment> Comments { get; set; } = [];
    public List<Reaction> Reactions { get; set; } = [];
}