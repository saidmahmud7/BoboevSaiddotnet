Console.WriteLine("Hello World!");

class PaymentProcessor
{
    public void ProcessPayment(string paymentType, double amount)
    {
        if (paymentType == "CreditCard")
        {
            Console.WriteLine($"Payment with Credit Card of {amount}");
        }
        else if (paymentType == "Visa")
        {
            Console.WriteLine($"Payment with Visa of {amount}");
        }
        else if (paymentType == "Bitcoin")
        {
            Console.WriteLine($"Payment with Bitcoin of {amount}");
        }
        else
        {
            throw new Exception("Unsupported payment type");
        }
    }
}