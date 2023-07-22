using CaseManagementSystem.DbModel;
using CaseManagementSystem.Helper;
using CaseManagementSystem.Models;
using CaseManagementSystem.Services.Interface;
using CaseManagementSystem.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;

namespace CaseManagementSystem.Services.Implementation
{
   public class EmailRepository : IEmailService
   { 
       private readonly IConfiguration _configuration;
        public EmailRepository(IConfiguration configuration)
        {
               this._configuration = configuration;
        }

        public async Task<bool> SendMail(SendMail obj)
        {
           try
           {
               // Mail
               string userName = _configuration["EmailConfiguration:Username"];
               string password = _configuration["EmailConfiguration:Password"];
               string host = _configuration["EmailConfiguration:SmtpServer"];
               int port = int.Parse(_configuration["EmailConfiguration:Port"]);
               string mailFrom = _configuration["EmailConfiguration:From"];

               obj.SendBy = mailFrom;
               using (var client = new SmtpClient())
               {
                  var credential = new NetworkCredential
                  {
                     UserName = userName,
                     Password = password
                  };

                  client.Credentials = credential;
                  client.Host = host;
                  client.Port = port;
                  client.EnableSsl = true;

                  using (var emailMessage = new MailMessage())
                  {
                     emailMessage.To.Add(new MailAddress(obj.SendTo));
                     emailMessage.From = new MailAddress(obj.SendBy);
                     emailMessage.Subject = obj.MailSubject;
                     emailMessage.Body = obj.MailBody;
                     emailMessage.IsBodyHtml = (bool)obj.IsHtmlFormat;
                     client.Send(emailMessage);
                  }
               }
               await Task.CompletedTask;
               return true;
           }
           catch (Exception)
           {
               return false;
           }
        }
   }
}
