using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace GelecekBilimde.Backend
{
    [DependsOn(
        typeof(BackendDomainModule),
        typeof(BackendApplicationContractsModule),
        typeof(AbpIdentityApplicationModule),
        typeof(AbpPermissionManagementApplicationModule)
        )]
    public class BackendApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                /* Use `true` for the `validate` parameter if you want to
                 * validate the profile on application startup.
                 * See http://docs.automapper.org/en/stable/Configuration-validation.html for more info
                 * about the configuration validation. */
                options.AddProfile<BackendApplicationAutoMapperProfile>();
            });
        }
    }
}
