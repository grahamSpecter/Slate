using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slate.Models;

namespace Slate.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet properties
        public DbSet<Entity> Entities { get; set; }
        public DbSet<Matter> Matters { get; set; }

        // Additional DbSet properties for other entities if needed

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=WINDOWS-7U6TQBQ\\SQLEXPRESS;Database=Slate;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
