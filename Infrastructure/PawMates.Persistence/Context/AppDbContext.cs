using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using PawMates.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace PawMates.Persistence.Context
{
    public class AppDbContext : IdentityDbContext<User, Role, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LostAd> LostAds { get; set; }
        public DbSet<JobAd> JobAds { get; set; }
        public DbSet<AdoptionAd> AdoptionAds { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configure Identity tables to use uuid
            modelBuilder.Entity<User>(entity => entity.Property(m => m.Id).HasColumnType("uuid"));
            modelBuilder.Entity<Role>(entity => entity.Property(m => m.Id).HasColumnType("uuid"));
            modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.Property(m => m.UserId).HasColumnType("uuid");
                entity.Property(m => m.RoleId).HasColumnType("uuid");
            });
       
            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.Property(m => m.UserId).HasColumnType("uuid");
            });
       
            modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.Property(m => m.UserId).HasColumnType("uuid");
            });
        }
    }
}
