using GelecekBilimde.Backend.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace GelecekBilimde.Backend
{
    [DependsOn(
        typeof(BackendEntityFrameworkCoreTestModule)
        )]
    public class BackendDomainTestModule : AbpModule
    {

    }
}