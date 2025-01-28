using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Group
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; } 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
    public List<Student> Students { get; set; }
}