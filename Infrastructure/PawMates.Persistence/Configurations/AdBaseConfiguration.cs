using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawMates.Domain.Entities;

public class AdBaseConfiguration : IEntityTypeConfiguration<AdBase>
{
    public void Configure(EntityTypeBuilder<AdBase> builder)
    {
        builder.ToTable("Ads");

        // Configure discriminator for TPH
        builder.HasDiscriminator<string>("AdType")
            .HasValue<LostAd>("LostAd")
            .HasValue<JobAd>("JobAd")
            .HasValue<AdoptionAd>("AdoptionAd");

        // Define a primary key
        builder.HasKey(p => p.Id);

        // Common properties
        builder.Property(p => p.Title).IsRequired();
        builder.Property(p => p.Description).HasMaxLength(500);

        // Relationships
        builder.HasOne(p => p.User)
            .WithMany(u => u.Ads)
            .HasForeignKey(p => p.UserId)
            .IsRequired();
    }
}
