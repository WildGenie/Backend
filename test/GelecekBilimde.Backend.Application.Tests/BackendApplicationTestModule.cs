using Volo.Abp.Modularity;

namespace GelecekBilimde.Backend
{
    [DependsOn(
        typeof(BackendApplicationModule),
        typeof(BackendDomainTestModule)
        )]
    public class BackendApplicationTestModule : AbpModule
    {

    }
}