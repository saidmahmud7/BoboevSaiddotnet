using task1;
abstract class Payment : IPayment
{
    public abstract void ProcessPayment(decimal amount);
}

class CreditCardPayment : Payment, IRefundablePayment
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing credit card payment of {amount}");
    }

    public void RefundPayment(decimal amount)
    {
        Console.WriteLine($"Refunding {amount} to credit card.");
    }
}

class BitcoinPayment : Payment
{
    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Bitcoin payment of {amount}");
    }
}