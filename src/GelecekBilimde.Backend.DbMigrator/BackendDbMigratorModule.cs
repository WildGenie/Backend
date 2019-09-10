using GelecekBilimde.Backend.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace GelecekBilimde.Backend.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(BackendEntityFrameworkCoreDbMigrationsModule),
        typeof(BackendApplicationContractsModule)
        )]
    public class BackendDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<BackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
