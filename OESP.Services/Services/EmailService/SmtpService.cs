using System.Net.Mail;
using System.Net;
using OESP.Domain.Services.Interfaces;
using OESP.Domain.Commands;
using System;
using OESP.Domain.Handlers;
using OESP.Domain.Respositories;
using OESP.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace OESP.Services.Services.Email
{
    public class SmtpService : IServiceBase
    {
        SmtpClient _smtp;
        IServiceProvider ServiceProvider { get; }
        public SmtpService()
        {
            _smtp = new SmtpClient();
            SmtpConfig();
        }
        public void SmtpConfig()
        {
            _smtp.Host = "smtp.gmail.com";
            _smtp.Port = 587;
            _smtp.EnableSsl = true;
        }

        public bool SendEmail(MailMessage mail, NetworkCredential credential)
        {
            try
            {
                _smtp.Credentials = credential;
                _smtp.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}