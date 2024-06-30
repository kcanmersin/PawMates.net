using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PawMates.net.Models;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Ad> Ads { get; set; }
    public DbSet<JobAd> JobAds { get; set; }
    public DbSet<LostAd> LostAds { get; set; }
    public DbSet<AdoptionAd> AdoptionAds { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Pet configuration
        builder.Entity<Pet>(entity =>
        {
            entity.HasKey(p => p.PetId);
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.Type).HasMaxLength(100);
            entity.Property(p => p.Age);
            entity.Property(p => p.Description).HasMaxLength(500);
        });

        // Ad configuration
        builder.Entity<Ad>(entity =>
        {
            entity.HasKey(a => a.AdId);
            entity.Property(a => a.DatePosted).HasDefaultValueSql("GETDATE()");
            entity.Property(a => a.Title).IsRequired().HasMaxLength(200);
            entity.Property(a => a.Description).IsRequired(); // Ensure Description is required
            entity.Property(a => a.Location).HasMaxLength(200);

            // Define discriminator for different types of ads
            entity.HasDiscriminator<string>("AdType")
                  .HasValue<LostAd>("LostAd")
                  .HasValue<AdoptionAd>("AdoptionAd")
                  .HasValue<JobAd>("JobAd");

            // Relationship between Ad and AppUser
            entity.HasOne(a => a.AppUser)
                  .WithMany(u => u.Ads)
                  .HasForeignKey(a => a.AppUserId)
                  .OnDelete(DeleteBehavior.Cascade); // Ensure cascading delete is correct for your needs

            // Relationship between Ad and Pets
            entity.HasMany(a => a.Pets)
                  .WithOne() // Assuming Pet does not need back reference to Ad
                  .HasForeignKey("AdId") // Optional if you want explicit FK column
                  .OnDelete(DeleteBehavior.Cascade); // Adjust according to your deletion policy
        });

        // AdoptionAd specific configuration
        builder.Entity<AdoptionAd>(entity =>
        {
            entity.Property(a => a.AdoptionFee).HasColumnType("decimal(18,2)");
        });

        // AppUser configuration (if any additional configuration needed)
        builder.Entity<AppUser>(entity =>
        {
             entity.Property(u => u.ProfilePictureUrl).HasMaxLength(2048);
            entity.Property(u => u.BackgroundPictureUrl).HasMaxLength(2048);
        });
builder.Entity<Pet>(entity =>
{
    entity.Property(p => p.ImageUrls).HasConversion(
        v => string.Join(';', v),
        v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList());
});


                    List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
    }
}
