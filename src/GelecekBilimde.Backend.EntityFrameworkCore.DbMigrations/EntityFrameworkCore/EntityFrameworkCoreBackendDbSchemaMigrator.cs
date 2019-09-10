using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GelecekBilimde.Backend.Data;
using Volo.Abp.DependencyInjection;

namespace GelecekBilimde.Backend.EntityFrameworkCore
{
    [Dependency(ReplaceServices = true)]
    public class EntityFrameworkCoreBackendDbSchemaMigrator 
        : IBackendDbSchemaMigrator, ITransientDependency
    {
        private readonly BackendMigrationsDbContext _dbContext;

        public EntityFrameworkCoreBackendDbSchemaMigrator(BackendMigrationsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateAsync()
        {
            await _dbContext.Database.MigrateAsync();
        }
    }
}