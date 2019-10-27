using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;

namespace GelecekBilimde.Backend
{
    [DependsOn(
        typeof(BackendDomainSharedModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule)
    )]
    public class BackendApplicationContractsModule : AbpModule
    {

    }
}
