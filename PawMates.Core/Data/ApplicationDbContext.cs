using Microsoft.EntityFrameworkCore;
using PawMates.Core.Data.Configurations;
using PawMates.Core.Data.Entity.Ads;
using PawMates.Core.Data.Entity;
using Core.Data.Entity.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Core.Data.Entity.User;
using Core.Data.Entity;
using Hangfire.Server;
namespace Pawmates.Core.Data
{

    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public ApplicationDbContext()
        {

        }

        public DbSet<AdoptionAd> AdoptionAds { get; set; }
        public DbSet<JobAd> JobAds { get; set; }
        public DbSet<LostAd> LostAds { get; set; }
        public DbSet<Pet> Pets { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<LikeDislike> LikesDislikes { get; set; }

        public DbSet<AdvertisementMedia> AdvertisementMedias { get; set; }
        public DbSet<PostMedia> PostMedias { get; set; }
        public DbSet<CommentMedia> CommentMedias { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
