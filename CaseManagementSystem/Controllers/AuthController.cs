using CaseManagementSystem.Helper;
using CaseManagementSystem.Models;
using CaseManagementSystem.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystem.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class AuthController : ControllerBase
   {
      private readonly IEmailService _emailService;
      private MessageHelper res = new MessageHelper();
      public AuthController(IEmailService emailService)
      {
               this._emailService = emailService;
      }
      [AllowAnonymous]
      [Route("GetLoginOTP")]
      [HttpGet]
      public async Task<IActionResult> GetLoginOTP(string mailAddress)
      {
         try
         {
            MessageHelper message = new MessageHelper();
            if (!string.IsNullOrEmpty(mailAddress))
            {
               Random generator = new Random();
               message.Message = generator.Next(0, 1000000).ToString("D6");
               message.StatusCode = 200;

               string mailBody = "<!DOCTYPE html>" +
                                   "<html>" +
                                   "<body>" +
                                       "<div style=" + '"' + "font-size:12px" + '"' +
                                           "<p>Hi <a href=" + '"' + '"' + "style=" + '"' + "color:blue" + '"' + ">" + mailAddress + "</a> </p>" +
                                           "<p>We received your request for a single-use code to use with your Powersoftit account.</p>" +
                                           "<p>Your single-use code is: " + message.Message + "</p>" +
                                           "<p>If you didn't request this code, you can safely ignore this email. Someone else might have typed your email address by mistake.</p>" +
                                           "<p>" +
                                               "Thanks, <Br /> " +
                                               "The Powersoftit team" +
                                           "</p>" +
                                       "</div>" +
                                   "</body>" +
                                   "</html>";

               SendMail sendMail = new SendMail
               {
                  SendTo = mailAddress,
                  SendBy = "",
                  MailSubject = "OTP",
                  MailBody = mailBody,
                  IsHtmlFormat = true
               };

               bool res = await _emailService.SendMail(sendMail);
               if (!res)
               {
                  message.StatusCode = 500;
                  message.Message = "Failed";
               }
               return Ok(message);
            }
            else
            {
               message.Message = "Mail Address was not passed";
               message.StatusCode = 401;

               return BadRequest(message);
            }
         }
         catch (Exception ex)
         {
            res.Message = ex.Message;
            res.StatusCode = 500;
            return BadRequest(res);
         }
      }
   }
}
