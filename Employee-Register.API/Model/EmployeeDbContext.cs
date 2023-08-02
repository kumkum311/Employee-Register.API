using Microsoft.EntityFrameworkCore;
namespace Employee_Register.API.Model
{
    public class EmployeeDbContext:DbContext
    {
        internal object Configuration;

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {
                
        }
        public DbSet<register> registers { get; set; }
        public DbSet<login> logins { get; set; }
    }
}
