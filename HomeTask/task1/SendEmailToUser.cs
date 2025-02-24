using System.Net;
using System.Net.Mail;

public class SendEmailToUser
{
    public void SendEmail(string from, string to, string text)
    {
        //from=> test@gmail.com
        //to=> test2@gmail.com
        //text => body
        try
        {
            var fromAddress = new MailAddress(from, "Sender Name");
            var toAddress = new MailAddress(to, "Recipient Name");
            const string subject = "Welcome Email"; 

            var smtp = new SmtpClient
            {
                Host = "smtp.example.com",
                Port = 587, 
                Credentials = new NetworkCredential(from, "your-email-password"),
                EnableSsl = true
            };

            using (var message = new MailMessage(fromAddress, toAddress)
                   {
                       Subject = subject,
                       Body = text
                   })
            {
                smtp.Send(message);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}