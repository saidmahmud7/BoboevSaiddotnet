namespace Domain.Enum;

public enum OrderStatus
{
    Created,
    Confirmed,
    InProgress,
    ReadyForDelivery,
    OnDelivery,
    Delivered,
    Cancelled
}