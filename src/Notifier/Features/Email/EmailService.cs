using Microsoft.Extensions.Options;
using Notifier.Features.Email.Contracts;
using System.Net;
using System.Net.Mail;

namespace Notifier.Features.Email;

public class EmailService(IOptions<AppSettings> options)
{
    public Task SendAsync(SendEmailRequest request)
    {
        var smtpClient = new SmtpClient("smtp.c1.liara.email")
        {
            Port = 587,
            Credentials = new NetworkCredential(options.Value.EmailUserName, options.Value.EmailPassword),
            EnableSsl = true
        };

        MailMessage message = 
            new MailMessage("no-replay@thisisnabi.dev",
                            request.To,
                            request.Subject,
                            request.Content);

        try
        {
            smtpClient.Send(message);
            Console.WriteLine("email sent successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"error in sending email: {ex.Message}");
        }



        return Task.CompletedTask;
    }
}
