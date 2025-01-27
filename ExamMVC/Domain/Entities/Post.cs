using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Post
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = null!;
    [Required(ErrorMessage = "Content is required")]
    public string Content { get; set; } = null!;
    public DateTime PublishedDate { get; set; }
    [Required]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<PostImage> PostImages { get; set; } = new List<PostImage>();
}
