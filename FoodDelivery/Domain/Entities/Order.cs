using Domain.Enum;

namespace Domain.Entities;

public class Order
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
    public Courier Courier { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    List<OrderDetail> OrderDetails { get; set; }
}