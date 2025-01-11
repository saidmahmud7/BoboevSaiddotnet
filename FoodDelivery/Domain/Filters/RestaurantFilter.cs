namespace Domain.Filters;

public record RestaurantFilter : BaseFilter
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public decimal? Rating { get; set; }
    public string? Description { get; set; }
    public string? ContactPhone { get; set; }
}