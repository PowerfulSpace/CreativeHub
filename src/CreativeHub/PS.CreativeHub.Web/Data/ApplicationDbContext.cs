using Microsoft.EntityFrameworkCore;
using PS.CreativeHub.Web.Models;

namespace PS.CreativeHub.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<ContactFormEntry> ContactFormEntries { get; set; }
    }
}
