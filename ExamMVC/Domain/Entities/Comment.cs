using System.ComponentModel.DataAnnotations;

namespace Domain;

public class Comment
{
    public int Id { get; set; }

    [Required]
    public string Content { get; set; } = null!;

    [Required]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    [Required]
    public string AuthorName { get; set; } = null!;

    [Required]
    public int PostId { get; set; }

    public  Post Post { get; set; }
}