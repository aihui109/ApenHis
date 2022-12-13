using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace ApenHis.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public abstract class DbContextFactory<T> : IDesignTimeDbContextFactory<T>  where T : AbpDbContext<T>
{
    /// <summary>
    /// 创建DbContext实例
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public abstract T CreateDbContext(DbContextOptions<T> options);
    public T CreateDbContext(string[] args)
    {
        ApenHisEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<T>();
        var connName = ConnectionStringNameAttribute.GetConnStringName<T>();
        var connString = configuration.GetConnectionString(connName);
        DbContextOptionsConfigurer.Configure(builder, connString);
        //return (T)Activator.CreateInstance(typeof(T), builder.Options);
        return CreateDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ApenHis.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
