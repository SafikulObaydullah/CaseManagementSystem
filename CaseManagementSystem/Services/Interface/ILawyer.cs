using CaseManagementSystem.Helper;
using CaseManagementSystem.Models;
using CaseManagementSystem.ViewModel;

namespace CaseManagementSystem.Services.Interface
{
   public interface ILawyer
   {
       Task<MessageHelper> CreateLawyer(LawyerVM  lawyer);
       Task<List<LawyerVM>> GetLawyer();
       Task<MessageHelper> UpdateLawyer(LawyerVM lawyer);
       Task<MessageHelper> DeleteLawyer(int lawyerId);
   }
}
