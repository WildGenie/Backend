using GelecekBilimde.Backend.Articles;
using GelecekBilimde.Backend.Bookmarks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.Identity;

namespace GelecekBilimde.Backend
{
    [DependsOn(
        typeof(BackendDomainSharedModule),
        typeof(AbpAuditLoggingDomainModule),
        typeof(AbpBackgroundJobsDomainModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpPermissionManagementDomainIdentityModule)
        )]
    public class BackendDomainModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton<IArticleStore, WordpressArticleStore>();
            context.Services.AddTransient<IArticleBookmarkService, ArticleBookmarkService>();
        }
    }
}
