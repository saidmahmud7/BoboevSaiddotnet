using System.Net;
using System.Net.Mail;

public class SendLogsEmailToUser
{
    public void SendErrorEmail(string message)
    {
        try
        {
            var fromAddress = new MailAddress("noseh@tagaymurodzoda@gmail.com", "Noseh");
            var toAddress = new MailAddress("admin@example.com", "Admin");
            const string subject = "Error Notification";
            string body = $"An error occurred: {message}\nPlease check the application for further details.";

            var smtp = new SmtpClient
            {
                Host = "smtp.example.com",
                Port = 587,
                Credentials = new NetworkCredential("noseh@tagaymurodzoda@gmail.com", "noseh"),
                EnableSsl = true
            };

            using (var emailMessage = new MailMessage(fromAddress, toAddress)
                   {
                       Subject = subject,
                       Body = body
                   })
            {
                smtp.Send(emailMessage);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending error email: {ex.Message}");
        }
    }
}