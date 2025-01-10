using Domain.Entities;
using Domain.Enum;

namespace Domain.DTO_s.OrderDto;

public class GetOrderDto
{
    public int Id { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? DeliveredAt { get; set; }
    public decimal TotalAmount { get; set; }
    public string DeliveryAddress { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public int CourierId { get; set; }
    public int RestaurantId { get; set; }
    public int UserId { get; set; }
}