﻿using Domain.Entities;

namespace Domain.DTO_s.MenuDto;

public class GetMenuDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public bool IsAvailable { get; set; }
    public int PreparationTime { get; set; }
    public int Weight { get; set; }
    public string PhotoUrl { get; set; }
    public int RestaurantId { get; set; }
}