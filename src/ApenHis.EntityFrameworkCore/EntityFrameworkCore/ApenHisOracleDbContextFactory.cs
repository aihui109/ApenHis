using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace ApenHis.EntityFrameworkCore;

public class ApenHisOracleDbContextFactory : DbContextFactory<ApenHisOracleDbContext>
{
    public override ApenHisOracleDbContext CreateDbContext(DbContextOptions<ApenHisOracleDbContext> options)
    {
        return new ApenHisOracleDbContext(options);
    }
}
