namespace  validate;

public static class ValidatePayments
{
    public static bool ValidatePayment(Order order)
    {
        // Simulate payment validation
        return order.Amount > 0;
    }

    
}