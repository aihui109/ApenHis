using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.Oracle;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace ApenHis.EntityFrameworkCore;

[DependsOn(
    typeof(ApenHisDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpEntityFrameworkCoreOracleModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpFeatureManagementEntityFrameworkCoreModule)
    )]
public class ApenHisEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        ApenHisEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<ApenHisDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        context.Services.AddAbpDbContext<ApenHisOracleDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });
        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also ApenHisMigrationsDbContextFactory for EF Core tooling. */
            options.UseSqlServer();
            options.UseOracle<ApenHisOracleDbContext>(context =>
            {
                context.UseOracleSQLCompatibility("11");
            });
            //options.Configure<ApenHisDbContext>(context =>
            //{
            //    configDbContext(context);
            //});
            //options.Configure<ApenHisOracleDbContext>(context =>
            //{
            //    configDbContext(context);
            //});
        });

        void configDbContext<T>(AbpDbContextConfigurationContext<T> context) where T: AbpDbContext<T>
        {
            if (context.ExistingConnection != null)
            {
                DbContextOptionsConfigurer.Configure(context.DbContextOptions, context.ExistingConnection);
            }
            else
            {
                DbContextOptionsConfigurer.Configure(context.DbContextOptions, context.ConnectionString);
            }
        }
    }
}
