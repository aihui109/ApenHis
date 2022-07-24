using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ApenHis.Data;

/* This is used if database provider does't define
 * IApenHisDbSchemaMigrator implementation.
 */
public class NullApenHisDbSchemaMigrator : IApenHisDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
