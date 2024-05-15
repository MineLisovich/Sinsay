using MailKit.Net.Smtp;
using MimeKit;

namespace Sinsay.Sevices
{
    public class SendEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("Администрация  Sinsay", "deelimpay@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.mail.ru", 465, true);
                await client.AuthenticateAsync("deelimpay@mail.ru", "uRAxchK0veqpTnjPkMcJ");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);

            }

        }
    }
}
