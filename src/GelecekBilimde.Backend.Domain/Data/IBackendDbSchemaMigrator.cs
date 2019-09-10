using System.Threading.Tasks;

namespace GelecekBilimde.Backend.Data
{
    public interface IBackendDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
