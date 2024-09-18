using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawMates.Core.Data.Entity.Ads;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Data.Configurations
{
    public class AdConfiguration : IEntityTypeConfiguration<AdvertisementBase>
    {
        public void Configure(EntityTypeBuilder<AdvertisementBase> builder)
        {
            builder.ToTable("Advertisements");

            builder.HasKey(ad => ad.Id);

            builder.HasOne(ad => ad.User)
                   .WithMany(u => u.Advertisements)
                   .HasForeignKey(ad => ad.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(ad => ad.Title).IsRequired().HasMaxLength(200);
            builder.Property(ad => ad.Description).IsRequired().HasMaxLength(1000);
            builder.Property(ad => ad.Location).IsRequired().HasMaxLength(200);

            builder.HasDiscriminator<string>("AdType")
                   .HasValue<AdoptionAd>("Adoption")
                   .HasValue<JobAd>("Job")
                   .HasValue<LostAd>("Lost");

            // Configure relationship with comments
            builder.HasMany(ad => ad.Comments)
                   .WithOne(c => c.Advertisement)
                   .HasForeignKey(c => c.AdvertisementId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship with media
            builder.HasMany(ad => ad.Media)
                   .WithOne(m => m.Advertisement)
                   .HasForeignKey(m => m.AdvertisementId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class AdoptionAdConfiguration : IEntityTypeConfiguration<AdoptionAd>
    {
        public void Configure(EntityTypeBuilder<AdoptionAd> builder)
        {
            builder.Property(a => a.IsVaccinated).HasDefaultValue(false);
        }
    }

    public class JobAdConfiguration : IEntityTypeConfiguration<JobAd>
    {
        public void Configure(EntityTypeBuilder<JobAd> builder)
        {
            builder.Property(j => j.Salary).HasColumnType("decimal(18,2)");
            builder.Property(j => j.RequiredDays).HasMaxLength(50);
        }
    }

    public class LostAdConfiguration : IEntityTypeConfiguration<LostAd>
    {
        public void Configure(EntityTypeBuilder<LostAd> builder)
        {
            builder.Property(l => l.LastSeenLocation).HasMaxLength(200);

            builder.Property(l => l.LostDate)
                   .IsRequired()
                   .HasColumnType("timestamp with time zone")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP AT TIME ZONE 'UTC'");
        }
    }
}
