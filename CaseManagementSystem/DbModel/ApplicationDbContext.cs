using CaseManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CaseManagementSystem.DbModel
{
   public class ApplicationDbContext : DbContext
   {
      public ApplicationDbContext(DbContextOptions options) : base(options)
      {
      }
      public DbSet<Lawyer> Lawyers { get; set; }   
   }
}
