using Volo.Abp.Modularity;

namespace GelecekBilimde.Backend
{
    [DependsOn(
        typeof(BackendApplicationContractsModule)
    )]
    public class BackendHttpApiModule : AbpModule
    {
        
    }
}
