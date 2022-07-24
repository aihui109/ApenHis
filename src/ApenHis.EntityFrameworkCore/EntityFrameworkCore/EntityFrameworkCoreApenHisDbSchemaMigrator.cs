using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApenHis.Data;
using Volo.Abp.DependencyInjection;

namespace ApenHis.EntityFrameworkCore;

public class EntityFrameworkCoreApenHisDbSchemaMigrator
    : IApenHisDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreApenHisDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the ApenHisDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<ApenHisDbContext>()
            .Database
            .MigrateAsync();
    }
}
