using Microsoft.EntityFrameworkCore;
using testWebMVCApp.Models;

namespace testWebMVCApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BULKY;User ID=sa;Password=MyScooby1*");
        }

        public DbSet<Category> Categories { get; set; }
    }
}
