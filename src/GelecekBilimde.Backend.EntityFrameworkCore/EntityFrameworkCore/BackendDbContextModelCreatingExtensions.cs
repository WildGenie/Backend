using GelecekBilimde.Backend.Articles.Bookmarks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Users;

namespace GelecekBilimde.Backend.EntityFrameworkCore
{
    public static class BackendDbContextModelCreatingExtensions
    {
        public static void ConfigureBackend(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(BackendConsts.DbTablePrefix + "YourEntities", BackendConsts.DbSchema);

            //    //...
            //});

            builder.Entity<UserArticleBookmark>(b =>
            {
                b.ToTable(BackendConsts.DbTablePrefix + "UserArticleBookmarks", BackendConsts.DbSchema);

                b.Property(c => c.ArticleId)
                    .IsRequired();

                b.Property(c => c.UserId)
                    .IsRequired();

                b.HasKey(c => new { c.UserId, c.ArticleId });

                b.ConfigureByConvention();
            });
        }

        public static void ConfigureCustomUserProperties<TUser>(this EntityTypeBuilder<TUser> b)
            where TUser : class, IUser
        {
            //b.Property<string>(nameof(AppUser.MyProperty))...
        }
    }
}