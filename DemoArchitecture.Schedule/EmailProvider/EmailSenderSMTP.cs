using DemoArchitecture.Entity.Entities;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DemoArchitecture.Schedule.EmailProvider
{
    public class EmailSenderSMTP
    {
        private readonly SmtpClient _smtpClient;

        public EmailSenderSMTP(string host, int port, string username, string password)
        {
            SmtpClient smtpClient = new SmtpClient(host);
            smtpClient.Port = port;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new System.Net.NetworkCredential(username, password);
            _smtpClient = smtpClient;
        }

        public async Task<bool> SendMail(Email outboxMail)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Sender = new MailAddress(outboxMail.EmailSenderAddress, outboxMail.EmailSenderName);
            mailMessage.From = new MailAddress(outboxMail.EmailSenderAddress, outboxMail.EmailSenderName);
            mailMessage.Subject = outboxMail.Subject;
            mailMessage.Body = outboxMail.Body;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;


            mailMessage.To.Add(new MailAddress(outboxMail.Recipients));
            try
            {
                await _smtpClient.SendMailAsync(mailMessage);

            }
            catch (SmtpException ex)
            {
                return false;
            };
            return true;

        }

        public void Dispose()
        {
            _smtpClient.Dispose();
        }


    }

}
