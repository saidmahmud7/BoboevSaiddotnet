using log;
using sendemail;
using validate;

class OrderService
{
    public void ProcessOrder(Order order)
    {
        if (!ValidatePayments.ValidatePayment(order))
        {
            Console.WriteLine("Payment validation failed.");
            return;
        }
        SaveOrderToDatabase(order);
        SendOrderConfirmationEmails.SendOrderConfirmationEmail(order.CustomerEmail);
        Logger.LogOrderProcessing(order);
    }
    private void SaveOrderToDatabase(Order order)
    {
        Console.WriteLine("Order saved to database.");
    }
    
}