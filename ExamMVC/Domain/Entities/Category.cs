namespace Domain;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public List<Post> Posts { get; set; } = new List<Post>();
}
