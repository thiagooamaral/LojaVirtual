﻿using LojaVirtual.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;

namespace LojaVirtual.Libraries.Email
{
    public class GerenciarEmail
    {
        private SmtpClient _smtp;
        private IConfiguration _configuration;

        public GerenciarEmail(SmtpClient smtp, IConfiguration configuration)
        {
            _smtp = smtp;
            _configuration = configuration;
        }

        public void EnviarContatoPorEmail(Contato contato)
        {
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
            message.From = new MailAddress(_configuration.GetValue<string>("Email:Username"));
            message.To.Add(contato.Email);
            message.Subject = "Contato - LojaVirtual - E-mail: " + contato.Email;
            message.Body = corpoMsg;
            message.IsBodyHtml = true;

            //Enviar mensagem via SMTP
            _smtp.Send(message);
        }

        public void EnviarSenhaParaColaboradorPorEmail(Colaborador colaborador)
        {
            string corpoMsg = string.Format("<h2>Colaborador - LojaVirtual</h2>" +
                "Sua senha é:" +
                "<h3>{0}</h3>", colaborador.Senha);

            //MailMessage: Construir a mensagem
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_configuration.GetValue<string>("Email:Username"));
            message.To.Add(colaborador.Email);
            message.Subject = "Colaborador - LojaVirtual - Senha do colaborador " + colaborador.Nome;
            message.Body = corpoMsg;
            message.IsBodyHtml = true;

            //Enviar mensagem via SMTP
            _smtp.Send(message);
        }
    }
}
