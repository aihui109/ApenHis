using System.Threading.Tasks;

namespace ApenHis.Data;

public interface IApenHisDbSchemaMigrator
{
    Task MigrateAsync();
}
