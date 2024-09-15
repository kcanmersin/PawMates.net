using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Data.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pets");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.PetType)
                   .WithMany(pt => pt.Pets)
                   .HasForeignKey(p => p.PetTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Advertisement)
                   .WithMany(a => a.Pets)
                   .HasForeignKey(p => p.AdvertisementId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Breed).HasMaxLength(100);
            builder.Property(p => p.Gender).IsRequired().HasMaxLength(20);
            builder.Property(p => p.Description).HasMaxLength(500);
            builder.Property(p => p.Age).IsRequired();
        }
    }
}
