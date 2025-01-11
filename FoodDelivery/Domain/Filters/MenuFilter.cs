namespace Domain.Filters;

public record MenuFilter : BaseFilter
{
    public string? Name { get; set; }
    public string? Category { get; set; }
    public int? PreparationTime { get; set; }
    public int? Weight { get; set; }
    public decimal? Price { get; set; }
    public int? RestaurantId { get; set; }
}