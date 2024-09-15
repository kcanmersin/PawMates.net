using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawMates.Core.Data.Entity;
using System;

namespace PawMates.Core.Data.Configurations
{
    public class PetTypeConfiguration : IEntityTypeConfiguration<PetType>
    {
        public void Configure(EntityTypeBuilder<PetType> builder)
        {
            // Table name
            builder.ToTable("PetTypes");

            // Primary key
            builder.HasKey(pt => pt.Id);

            // Property configurations
            builder.Property(pt => pt.Species).IsRequired().HasMaxLength(100);
            builder.Property(pt => pt.Description).HasMaxLength(500);

            // Relationships
            builder.HasMany(pt => pt.Pets)
                   .WithOne(p => p.PetType)
                   .HasForeignKey(p => p.PetTypeId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Seed data with fixed Guids
            builder.HasData(
                new PetType
                {
                    Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), // Dog
                    Species = "Dog",
                    Description = "Common domestic dog"
                },
                new PetType
                {
                    Id = Guid.Parse("4fa85f64-5717-4562-b3fc-2c963f66afa7"), // Cat
                    Species = "Cat",
                    Description = "Common domestic cat"
                },
                new PetType
                {
                    Id = Guid.Parse("5fa85f64-5717-4562-b3fc-2c963f66afa8"), // Bird
                    Species = "Bird",
                    Description = "Common domestic bird"
                }
            );
        }
    }
}
