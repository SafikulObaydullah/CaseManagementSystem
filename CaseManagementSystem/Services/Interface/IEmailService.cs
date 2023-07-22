using CaseManagementSystem.Models;

namespace CaseManagementSystem.Services.Interface
{
   public interface IEmailService
   {
      Task<bool> SendMail(SendMail obj);
   }
}
