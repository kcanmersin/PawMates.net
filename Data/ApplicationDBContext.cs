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

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Set up relationships and properties for Pet and Ad
        builder.Entity<Pet>(entity =>
        {
            entity.HasKey(p => p.PetId);
            entity.Property(p => p.Name).IsRequired();
            entity.Property(p => p.Type).HasMaxLength(100);
            entity.Property(p => p.Age);
            entity.Property(p => p.Description).HasMaxLength(500);

            // Relationship Pet-Ads
            entity.HasMany(p => p.Ads)
                  .WithOne(a => a.Pet)
                  .HasForeignKey(a => a.PetId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<Ad>(entity =>
        {
            entity.HasKey(a => a.AdId);
            entity.Property(a => a.DatePosted).HasDefaultValueSql("GETDATE()");
            entity.Property(a => a.Title).IsRequired().HasMaxLength(200);
            entity.Property(a => a.Location).HasMaxLength(200);

            // Define discriminator for different types of ads
            entity.HasDiscriminator<string>("AdType")
                  .HasValue<LostAd>("LostAd")
                  .HasValue<AdoptionAd>("AdoptionAd")
                  .HasValue<JobAd>("JobAd");
        });

        builder.Entity<AppUser>(entity =>
        {
        });

    }
}
