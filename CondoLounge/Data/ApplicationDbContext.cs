using CondoLounge.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CondoLounge.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Create a table in the database
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Condo> Condos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Calls the IdentityDbContext configuration so all Identity tables
            // are created correctly before applying our own custom rules.
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Building>()
            .HasIndex(o => o.BuildingId)
            .IsUnique();

            modelBuilder.Entity<Condo>()
            .HasIndex(o => o.CondoId)
            .IsUnique();
        }
    }
}
