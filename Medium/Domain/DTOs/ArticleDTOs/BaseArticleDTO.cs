namespace Domain.DTOs.ArticleDTOs;

public class BaseArticleDTO
{
    public string Title { get; set; }
    public string Content { get; set; }
    public bool IsPremium { get; set; }
    public bool IsDraft { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? PublishedAt { get; set; }
    public List<string> Tags { get; set; }
    public int AuthorId { get; set; }
}
