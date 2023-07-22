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
   public class LawyerRepository : ILawyer
   {
       private readonly ApplicationDbContext _context;
       private readonly IConfiguration _configuration;
      public LawyerRepository(ApplicationDbContext context, IConfiguration configuration)
        {
               this._context = context;
               this._configuration = configuration;
        }
        [HttpPost]
        public async Task<MessageHelper> CreateLawyer(LawyerVM lawyer)
        {
            Lawyer lw = new Lawyer()
            {
               Name = lawyer.Name,  
               Designation = lawyer.Designation,
               Address = lawyer.Address,
            };
             await _context.Lawyers.AddAsync(lw);
             await _context.SaveChangesAsync();
             return new MessageHelper()
             {
               Message = "Successfully Saved",
               StatusCode = 200,
             };
        }
      [HttpPost]
      public async Task<MessageHelper> UpdateLawyer(LawyerVM lawyer)
      {
         MessageHelper msg = new MessageHelper();
         Lawyer law = await _context.Lawyers.FirstOrDefaultAsync(x =>x.Id == lawyer.Id);
         if(law.Id>0)
         {
            law.Name = lawyer.Name;
            law.Designation = lawyer.Designation;
            law.Address = lawyer.Address; 
         }
          _context.Lawyers.Update(law);
         await _context.SaveChangesAsync();
         return new MessageHelper()
         {
            Message = "Successfully Updated",
            StatusCode = 200,
         };
      }

      [HttpGet]
        public async Task<List<LawyerVM>> GetLawyer()
      {
         List<LawyerVM> data = await ( from a in _context.Lawyers 
                                         select new LawyerVM { 
                                         Name = a.Name, 
                                         Designation = a.Designation,
                                         Address = a.Address 
                                      }).ToListAsync();
         return  data;
      }

      public async Task<MessageHelper> DeleteLawyer(int lawyerId)
      {
         bool result = false;
         var lawyer = _context.Lawyers.Find(lawyerId);
         if (lawyer != null)
         {
            _context.Entry(lawyer).State = EntityState.Deleted;
           await _context.SaveChangesAsync();
            result = true;
         }
         else
         {
            result = false;
         }
         return new MessageHelper()
         {
            Message = "Lawyer Deleted",
            StatusCode = 200,
         };
      }

   }
}
