namespace CaseManagementSystem.Models
{
   public class SendMail
   {
      public string SendTo { get; set; }
      public string SendBy { get; set; }
      public string MailSubject { get; set; }
      public string MailBody { get; set; }
      public bool? IsHtmlFormat { get; set; }
   }
}
