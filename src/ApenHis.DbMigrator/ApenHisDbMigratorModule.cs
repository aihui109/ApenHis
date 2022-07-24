using ApenHis.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ApenHis.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(ApenHisEntityFrameworkCoreModule),
    typeof(ApenHisApplicationContractsModule)
    )]
public class ApenHisDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
