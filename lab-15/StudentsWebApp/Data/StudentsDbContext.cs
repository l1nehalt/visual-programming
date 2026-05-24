using Microsoft.EntityFrameworkCore;
using StudentsWebApp.Models;

namespace StudentsWebApp.Data
{
    public class StudentsDbContext : DbContext
    {
        public StudentsDbContext(DbContextOptions<StudentsDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
