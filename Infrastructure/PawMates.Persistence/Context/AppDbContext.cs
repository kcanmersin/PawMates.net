using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using PawMates.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;

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
        //public DbSet<AdImage> AdImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
