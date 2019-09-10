using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace GelecekBilimde.Backend.EntityFrameworkCore
{
    [DependsOn(
        typeof(BackendEntityFrameworkCoreModule)
        )]
    public class BackendEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BackendMigrationsDbContext>();
        }
    }
}
