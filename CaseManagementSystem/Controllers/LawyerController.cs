using CaseManagementSystem.Services.Interface;
using CaseManagementSystem.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystem.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class LawyerController : ControllerBase
   {
      private readonly ILawyer _lawyer;
      public LawyerController(ILawyer lawyer)
      {
         this._lawyer = lawyer;
      }
      [HttpPost("CreateLaywer")]
      public async Task<IActionResult> CreateLaywer(LawyerVM obj)
      {
         try
         {
            var res = await _lawyer.CreateLawyer(obj);
            return Ok(res);
         }
         catch (Exception EX)
         {
            throw EX;
         }
      }
      [HttpGet("GetLawyer")]
      public async Task<IActionResult> GetLawyer()
      {
         try
         {
            var res = await _lawyer.GetLawyer();
            return Ok(res);
         }
         catch (Exception EX)
         {
            throw EX;
         }
      }
      [HttpPut("UpdateLawyer")]
      public async Task<IActionResult> UpdateLawyer(LawyerVM lawyer)
      {
         try
         {
            var res = await _lawyer.UpdateLawyer(lawyer);
            return Ok(res);
         }
         catch (Exception EX)
         {
            throw EX;
         }
      }
      [HttpDelete("DeleteLawyer")]
      public async Task<IActionResult> DeleteLawyer(int Id)
      {
         try
         {
            var res = await _lawyer.DeleteLawyer(Id);
            return Ok(res);
         }
         catch (Exception EX)
         {
            throw EX;
         }
      }
   }
}
