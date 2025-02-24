namespace sendemail;

public static class SendOrderConfirmationEmails
{
    public static void SendOrderConfirmationEmail(string customerEmail)
    {

        Console.WriteLine($"Email sent to {customerEmail}");
    }

}