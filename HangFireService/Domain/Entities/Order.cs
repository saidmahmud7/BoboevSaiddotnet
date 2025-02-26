namespace Domain.Entities;
using Domain.Enum;
public class Order
{
    public int Id { get; set; }
    public Type Type { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required string CustomerName { get; set; }
    public bool IsDiscountApplied { get; set; } = false;
    public DateTime DeliveryDeadline()
    {
        if (Type == Type.Express)
            return CreatedAt.AddHours(2);
        else if (Type == Type.Standard)
            return CreatedAt.AddDays(1);
        else if (Type == Type.Economy)
            return CreatedAt.AddDays(3);
        else
            throw new ArgumentException("Unknown order type");
    }
}