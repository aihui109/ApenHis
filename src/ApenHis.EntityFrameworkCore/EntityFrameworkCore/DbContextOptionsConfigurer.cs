using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.Common;
using Volo.Abp.EntityFrameworkCore;

namespace ApenHis.EntityFrameworkCore;

public static class DbContextOptionsConfigurer
{
    #region DefineLoggerFactory     
    public static readonly ILoggerFactory EFLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });
    #endregion DefineLoggerFactory
    public static void Configure<T>(
        DbContextOptionsBuilder<T> dbContextOptions,
        string connectionString) where T : AbpDbContext<T>
    {
#if DEBUG
        dbContextOptions.UseLoggerFactory(EFLoggerFactory);
        dbContextOptions.EnableSensitiveDataLogging();
        dbContextOptions.EnableDetailedErrors();
#endif
        /* This is the single point to configure DbContextOptions for EnterpriseDbContext */
        if (typeof(T) == typeof(ApenHisOracleDbContext))
            dbContextOptions.UseOracle(connectionString, options => options.UseOracleSQLCompatibility("11"));
        else
            dbContextOptions.UseSqlServer(connectionString);
    }

    public static void Configure<T>(
        DbContextOptionsBuilder<T> dbContextOptions,
        DbConnection connection) where T : AbpDbContext<T>
    {
#if DEBUG
        dbContextOptions.UseLoggerFactory(EFLoggerFactory);
        dbContextOptions.EnableSensitiveDataLogging();
        dbContextOptions.EnableDetailedErrors();
#endif
        /* This is the single point to configure DbContextOptions for EnterpriseDbContext */
        if (typeof(T) == typeof(ApenHisOracleDbContext))
            dbContextOptions.UseOracle(connection, options => options.UseOracleSQLCompatibility("11"));
        else
            dbContextOptions.UseSqlServer(connection);
    }
}
