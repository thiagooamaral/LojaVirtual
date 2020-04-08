using LojaVirtual.Models;
using System.Net;
using System.Net.Mail;

namespace LojaVirtual.Libraries.Email
{
    public class ContatoEmail
    {
        public static void EnviarContatoPorEmail(Contato contato)
        {
            //SMTP: Servidor que vai enviar a mensagem
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("tfmamaral@gmail.com", "G!52025258"),
                EnableSsl = true
            };

            string corpoMsg = string.Format("<h2>Contato - LojaVirtual</h2> <br />" +
                "<b>Nome: </b> {0} <br />" +
                "<b>E-mail: </b> {1} <br />" +
                "<b>Texto: </b> {2} <br />" +
                "<br /> E-mail enviado automaticamente do site LojaVirtual.",
                contato.Nome,
                contato.Email,
                contato.Texto);

            //MailMessage: Construir a mensagem
            MailMessage message = new MailMessage();
            message.From = new MailAddress("tfmamaral@gmail.com");
            message.To.Add(contato.Email);
            message.Subject = "Contato - LojaVirtual - E-mail: " + contato.Email;
            message.Body = corpoMsg;
            message.IsBodyHtml = true;

            //Enviar mensagem via SMTP
            smtp.Send(message);
        }
    }
}
