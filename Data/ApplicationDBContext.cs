using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawMates.net.Models;

namespace PawMates.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ad> Ads { get; set; }
        public DbSet<AdoptionAd> AdoptionAds { get; set; }
        public DbSet<JobAd> JobAds { get; set; }
        public DbSet<LostAd> LostAds { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Pet> Pets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure domain-specific constraints here
            modelBuilder.Entity<Ad>()
                .HasOne(a => a.AppUser)
                .WithMany(u => u.Ads)
                .HasForeignKey(a => a.AppUserId);

            modelBuilder.Entity<Ad>()
                .HasMany(a => a.Images)
                .WithOne(i => i.Ad)
                .HasForeignKey(i => i.AdId);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.Ad)
                .WithMany(a => a.Images)
                .HasForeignKey(i => i.AdId);

            // Configure any other relationships if needed
              modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Name = "User", NormalizedName = "USER" }
        );
        }
    }
}
