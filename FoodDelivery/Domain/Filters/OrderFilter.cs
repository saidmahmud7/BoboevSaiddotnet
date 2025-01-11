using Domain.Enum;

namespace Domain.Filters;

public record OrderFilter : BaseFilter
{
    public OrderStatus? OrderStatus { get; set; }
    public decimal? TotalAmount { get; set; }
    public string? DeliveryAddress { get; set; }
}