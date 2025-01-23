﻿namespace Domain.Filters;

public record OrderDetailFilter : BaseFilter
{
    public int? MenuItemId { get; set; }
    public int? Quantity { get; set; }
    public decimal? Price { get; set; }
    public string? SpecialInstructions { get; set; }
    public int? OrderId { get; set; }
}