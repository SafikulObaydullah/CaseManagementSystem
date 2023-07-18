using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseManagementSystem.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class LawyerController : ControllerBase
   {
        public LawyerController()
        {
               
        }
      [HttpPost]
      public string CreateLaywer()
      {
         return "";
      }
    }
}
