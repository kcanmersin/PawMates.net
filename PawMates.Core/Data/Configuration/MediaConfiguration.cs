using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawMates.Core.Data.Entity;
using PawMates.Core.Data.Entity.Ads;

namespace PawMates.Core.Data.Configurations
{
    public class MediaConfiguration : IEntityTypeConfiguration<AdvertisementMedia>, IEntityTypeConfiguration<PostMedia>, IEntityTypeConfiguration<CommentMedia>
    {
        public void Configure(EntityTypeBuilder<AdvertisementMedia> builder)
        {
            builder.HasKey(am => am.Id);

            builder.Property(am => am.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(am => am.MediaType)
                .IsRequired(); 

            builder.HasOne(am => am.Advertisement)
                .WithMany(ad => ad.Media)
                .HasForeignKey(am => am.AdvertisementId)
                .OnDelete(DeleteBehavior.Cascade); 
        }

        public void Configure(EntityTypeBuilder<PostMedia> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.FilePath)
                .IsRequired()
                .HasMaxLength(500); 

            builder.Property(pm => pm.MediaType)
                .IsRequired();

            builder.HasOne(pm => pm.Post)
                .WithMany(p => p.Media)
                .HasForeignKey(pm => pm.PostId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void Configure(EntityTypeBuilder<CommentMedia> builder)
        {
            builder.HasKey(cm => cm.Id);

            builder.Property(cm => cm.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(cm => cm.MediaType)
                .IsRequired();

            builder.HasOne(cm => cm.Comment)
                .WithMany(c => c.Media)
                .HasForeignKey(cm => cm.CommentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
