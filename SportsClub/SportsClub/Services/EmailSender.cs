using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using SportsClub.Areas.Identity.Pages.Account;
using System;
using System.IO;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SportsClub.Services
{
    public class EmailSender : IEmailSender, IObserver
    {
        private readonly ILogger _logger;

        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor,
                           ILogger<EmailSender> logger)
        {
            Options = optionsAccessor.Value;
            _logger = logger;
        }

        public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

        public void Update(IRegisterInfo registerInfo)
        {
            string path = @"F:\KNU\ООКП (Об'єктно-орієнтоване конструювання програм)\Лабораторні роботи\SportsClub\SportsClub\RegisterInfo\Logger.txt";
            
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine($"Користувача {(registerInfo as RegisterModel).user.FirstName} {(registerInfo as RegisterModel).user.LastName} " +
                        $"зареєстровано.\nПеревірте систему, щоб підтвердити користувача, або зв'язатись із ним.\n" +
                        $"На пошту {(registerInfo as RegisterModel).user.Email} надійшло підтвердження.\n");
                }
            }
            else
            {
                File.AppendAllText(path, $"Користувача {(registerInfo as RegisterModel).user.FirstName} {(registerInfo as RegisterModel).user.LastName} " +
                        $"зареєстровано.\nПеревірте систему, щоб підтвердити користувача, або зв'язатись із ним.\n" +
                         $"На пошту {(registerInfo as RegisterModel).user.Email} надійшло підтвердженняю\n");
            }
        }
        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            if (string.IsNullOrEmpty(Options.SendGridKey))
            {
                throw new Exception("Null SendGridKey");
            }
            await Execute(Options.SendGridKey, subject, message, toEmail);
        }

        public async Task Execute(string apiKey, string subject, string message, string toEmail)
        {
            string name = message.Split(" ")[0];
            string url = message.Split(" ")[1];
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("shadeonskiy@gmail.com", "SportsClub"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.SetTemplateId(chooseTemplateForEmail(subject));
            msg.SetTemplateData(new
            {
                subject = subject,
                name = name,
                url = url

            });
            msg.AddTo(new EmailAddress(toEmail));
            msg.SetClickTracking(false, false);

            var response = await client.SendEmailAsync(msg);
            _logger.LogInformation(response.IsSuccessStatusCode
                                   ? $"Email to {toEmail} queued successfully!"
                                   : $"Failure Email to {toEmail}");
        }

        private string chooseTemplateForEmail(string subject)
        {
            if (subject.Contains("Password"))
            {
                return Options.TemplateId[0];
            }
            return Options.TemplateId[1];
        }
    }

}