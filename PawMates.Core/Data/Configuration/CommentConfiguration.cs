using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Content).IsRequired().HasMaxLength(1000);

            builder.HasOne(c => c.User)
                   .WithMany()
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Advertisement)
                   .WithMany(ad => ad.Comments)
                   .HasForeignKey(c => c.AdvertisementId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(c => c.Post)
                   .WithMany(p => p.Comments)
                   .HasForeignKey(c => c.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configure nested comments
            builder.HasOne(c => c.ParentComment)
                   .WithMany(c => c.Replies)
                   .HasForeignKey(c => c.ParentCommentId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Configure relationship with LikeDislike
            builder.HasMany(c => c.LikesDislikes)
                   .WithOne(ld => ld.Comment)
                   .HasForeignKey(ld => ld.CommentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
