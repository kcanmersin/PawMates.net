using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawMates.Core.Data.Entity;

namespace PawMates.Core.Data.Configurations
{
    public class LikeDislikeConfiguration : IEntityTypeConfiguration<LikeDislike>
    {
        public void Configure(EntityTypeBuilder<LikeDislike> builder)
        {
            builder.ToTable("LikesDislikes");

            builder.HasKey(ld => ld.Id);

            builder.Property(ld => ld.IsLike).IsRequired();

            builder.HasOne(ld => ld.User)
                   .WithMany()
                   .HasForeignKey(ld => ld.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ld => ld.Advertisement)
                   .WithMany()
                   .HasForeignKey(ld => ld.AdvertisementId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ld => ld.Post)
                   .WithMany()
                   .HasForeignKey(ld => ld.PostId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ld => ld.Comment)
                   .WithMany(c => c.LikesDislikes)
                   .HasForeignKey(ld => ld.CommentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
