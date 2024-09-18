using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Content).IsRequired();

            builder.HasOne(p => p.User)
                   .WithMany()
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship with comments
            builder.HasMany(p => p.Comments)
                   .WithOne(c => c.Post)
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship with LikeDislike
            builder.HasMany(p => p.LikesDislikes)
                   .WithOne(ld => ld.Post)
                   .HasForeignKey(ld => ld.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship with media
            builder.HasMany(p => p.Media)
                   .WithOne(m => m.Post)
                   .HasForeignKey(m => m.PostId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
