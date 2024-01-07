using System.Net;
using System.Net.Mail;

namespace StudyWebApi.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool Enviar(string email, string assunto, string mensagem)
        {
            try
            {
                string host = _configuration.GetValue<string>("SMTP:Host");
                string nome = _configuration.GetValue<string>("SMTP:Nome");
                string username = _configuration.GetValue<string>("SMTP:UserName");
                string password = _configuration.GetValue<string>("SMTP:Password");
                int porta = _configuration.GetValue<int>("SMTP:Porta");

                MailMessage mailMessage = new MailMessage() { 
                    From = new MailAddress(username, nome)
                };

                mailMessage.To.Add(email);
                mailMessage.Subject = assunto;
                mailMessage.Body = mensagem;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.High;

                using (SmtpClient smtpClient = new SmtpClient(host, porta))
                {
                    smtpClient.Credentials = new NetworkCredential(username, password);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(mailMessage);
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
